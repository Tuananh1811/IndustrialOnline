using CncIndustrial.ViewModels.Common;

using System;
using System.Collections.Generic;
using System.Text;

namespace CncIndustrial.ViewModels.Catalog.Project
{
    public class GetProjectPagingRequest : PagingRequestBase
    {
        public string LanguageId { get; set; }
        public int? categoryId { get; set; }
       
       
    }
}
