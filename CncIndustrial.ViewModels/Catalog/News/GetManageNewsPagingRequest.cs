﻿using CncIndustrial.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CncIndustrial.ViewModels.Catalog.News
{
   public class GetManageNewsPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public string LanguageId { get; set; }

       
    }
}
