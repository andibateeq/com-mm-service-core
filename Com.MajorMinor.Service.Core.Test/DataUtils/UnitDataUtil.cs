﻿using Com.MM.Service.Core.Lib;
using Com.MM.Service.Core.Lib.Models;
using Com.MM.Service.Core.Lib.Services;
using Com.MM.Service.Core.Lib.ViewModels;
using Com.MM.Service.Core.Test.Helpers;
using Com.MM.Service.Core.Test.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.MM.Service.Core.Test.DataUtils
{
    public class UnitDataUtil : BasicDataUtil<CoreDbContext, UnitService, Unit>, IEmptyData<UnitViewModel>
    {
        public UnitDataUtil(CoreDbContext dbContext, UnitService service) : base(dbContext, service)
        {
        }

        public UnitViewModel GetEmptyData()
        {
            return new UnitViewModel();
        }

        public override Unit GetNewData()
        {
            string guid = Guid.NewGuid().ToString();

            return new Unit()
            {
                Name = string.Format("Unit {0}", guid),
                Code = string.Format("Unit {0}", guid),
            };
        }

        public override async Task<Unit> GetTestDataAsync()
        {
            var data = GetNewData();
            await this.Service.CreateModel(data);
            return data;
        }
    }
}
