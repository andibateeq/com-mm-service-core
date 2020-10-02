﻿using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.MM.Service.Core.Lib.Models
{
    public class Expedition : StandardEntity, IValidatableObject
    {
        [MaxLength(255)]
        public string UId { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Code { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
