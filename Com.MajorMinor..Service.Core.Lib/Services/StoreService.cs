﻿using Com.MM.Service.Core.Lib.Helpers;
using Com.MM.Service.Core.Lib.Interfaces;
using Com.MM.Service.Core.Lib.Models;
using Com.MM.Service.Core.Lib.ViewModels;
using Com.Moonlay.NetCore.Lib;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Com.MM.Service.Core.Lib.Services
{
    public class StoreService : BasicService<CoreDbContext, Store>, IMap<Store, StoreViewModel>
    {
        public StoreService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override Tuple<List<Store>, int, Dictionary<string, string>, List<string>> ReadModel(int Page = 1, int Size = 25, string Order = "{}", List<string> Select = null, string Keyword = null, string Filter = "{}")
        {
            IQueryable<Store> Query = this.DbContext.Stores;
            Dictionary<string, object> FilterDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(Filter);
            Query = ConfigureFilter(Query, FilterDictionary);
            Dictionary<string, string> OrderDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(Order);

            /* Search With Keyword */
            if (Keyword != null)
            {
                List<string> SearchAttributes = new List<string>()
                {
                     "Code","Name"
                };

                Query = Query.Where(General.BuildSearch(SearchAttributes), Keyword);
            }

            /* Const Select */
            List<string> SelectedFields = new List<string>()
            {
                 "_id","Code", "Name", "description"
            };

            Query = Query
                .Select(b => new Store
                {
                    Id = b.Id,
                    Code = b.Code,
                    Name = b.Name
                });

            /* Order */
            if (OrderDictionary.Count.Equals(0))
            {
                OrderDictionary.Add("_updatedDate", General.DESCENDING);

                Query = Query.OrderByDescending(b => b._LastModifiedUtc); /* Default Order */
            }
            else
            {
                string Key = OrderDictionary.Keys.First();
                string OrderType = OrderDictionary[Key];
                string TransformKey = General.TransformOrderBy(Key);

                BindingFlags IgnoreCase = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance;

                Query = OrderType.Equals(General.ASCENDING) ?
                    Query.OrderBy(b => b.GetType().GetProperty(TransformKey, IgnoreCase).GetValue(b)) :
                    Query.OrderByDescending(b => b.GetType().GetProperty(TransformKey, IgnoreCase).GetValue(b));
            }

            /* Pagination */
            Pageable<Store> pageable = new Pageable<Store>(Query, Page - 1, Size);
            List<Store> Data = pageable.Data.ToList<Store>();

            int TotalData = pageable.TotalCount;

            return Tuple.Create(Data, TotalData, OrderDictionary, SelectedFields);
        }
        public StoreViewModel MapToViewModel(Store season)
        {
            StoreViewModel seasonVM = new StoreViewModel();

            seasonVM.Id = season.Id;
            seasonVM.UId = season.Uid;
            seasonVM._IsDeleted = season._IsDeleted;
            seasonVM.Active = season.Active;
            seasonVM._CreatedUtc = season._CreatedUtc;
            seasonVM._CreatedBy = season._CreatedBy;
            seasonVM._CreatedAgent = season._CreatedAgent;
            seasonVM._LastModifiedUtc = season._LastModifiedUtc;
            seasonVM._LastModifiedBy = season._LastModifiedBy;
            seasonVM._LastModifiedAgent = season._LastModifiedAgent;
            seasonVM.code = season.Code;
            seasonVM.name = season.Name;


            return seasonVM;
        }

        public Store MapToModel(StoreViewModel seasonVM)
        {
            Store season = new Store();

            season.Id = seasonVM.Id;
            season.Uid = seasonVM.UId;
            season._IsDeleted = seasonVM._IsDeleted;
            season.Active = seasonVM.Active;
            season._CreatedUtc = seasonVM._CreatedUtc;
            season._CreatedBy = seasonVM._CreatedBy;
            season._CreatedAgent = seasonVM._CreatedAgent;
            season._LastModifiedUtc = seasonVM._LastModifiedUtc;
            season._LastModifiedBy = seasonVM._LastModifiedBy;
            season._LastModifiedAgent = seasonVM._LastModifiedAgent;
            season.Code = seasonVM.code;
            season.Name = seasonVM.name;

            return season;
        }

        public sealed class MaterialMap : ClassMap<StoreViewModel>
        {
            public MaterialMap()
            {
                Map(c => c.code).Index(0);
                Map(c => c.name).Index(1);
            }
        }

        public Task<List<Store>> GetStoreByCategory(string category)
        {
            var store = (from a in DbContext.Stores
                         where a.StoreCategory.Contains((string.IsNullOrWhiteSpace(category) ? a.StoreCategory : category))
                         select a).ToListAsync();
            return store;
        }
    }
}
