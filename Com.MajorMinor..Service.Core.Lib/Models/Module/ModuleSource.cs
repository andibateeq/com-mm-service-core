﻿using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Com.MM.Service.Core.Lib.Models.Module
{
    public class ModuleSource : StandardEntity, IValidatableObject
    {
        [StringLength(255)]
        public string SourceValue { get; set; }

        [StringLength(255)]
        public string UId { get; set; }

        public virtual int ModuleId { get; set; }
        [ForeignKey("ModuleId")]
        public virtual Module Module { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
