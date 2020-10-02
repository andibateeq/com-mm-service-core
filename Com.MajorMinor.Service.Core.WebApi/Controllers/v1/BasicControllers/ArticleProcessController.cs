﻿using Com.MM.Service.Core.Lib;
using Com.MM.Service.Core.Lib.Models;
using Com.MM.Service.Core.Lib.Services;
using Com.MM.Service.Core.Lib.ViewModels;
using Com.MM.Service.Core.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.MM.Service.Core.WebApi.Controllers.v1.BasicControllers
{

    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/articles/process")]
    public class ArticleProcessController : BasicController<ArticleProcesService, ArticleProces, ArticleProcesViewModel, CoreDbContext>
    {
        private new static readonly string ApiVersion = "1.0";
        public ArticleProcessController(ArticleProcesService service) : base(service, ApiVersion)
        {
        }
    }
}
