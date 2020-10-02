﻿using Com.MM.Service.Core.Lib.Helpers;
using System;

namespace Com.MM.Service.Core.Lib.ViewModels
{
    public class ArticleProcesViewModel : BasicViewModelOld
    {
        public string code { get; set; }

        public string name { get; set; }

        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
