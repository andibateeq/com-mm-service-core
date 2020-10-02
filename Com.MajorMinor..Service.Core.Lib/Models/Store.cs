﻿using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.MM.Service.Core.Lib.Models
{
    public class Store : StandardEntity, IValidatableObject
    {
        [StringLength(255)]
        public string Address { get; set; }
        [StringLength(255)]
        public string City { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        [StringLength(255)]
        public string Code { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public float MonthlyTotalCost { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string OnlineOffline { get; set; }
        public DateTimeOffset OpenedDate { get; set; }
        [StringLength(255)]
        public string Pic { get; set; }
        [StringLength(255)]
        public string Phone { get; set; }
        public float SalesCapital { get; set; }
        [StringLength(255)]
        public string SalesCategory { get; set; }
        public float SalesTarget { get; set; }
        [StringLength(255)]
        public string Status { get; set; }
        [StringLength(255)]
        public string StoreArea { get; set; }
        [StringLength(255)]
        public string StoreCategory { get; set; }
        [StringLength(255)]
        public string StoreWide { get; set; }
        [StringLength(255)]
        public string Uid { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // throw new NotImplementedException();

            List<ValidationResult> validationResult = new List<ValidationResult>();

            return validationResult;
        }

    }
}
