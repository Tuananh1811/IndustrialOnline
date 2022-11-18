using CncIndustrial.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CncIndustrial.ViewModels.Catalog.Project.Manage
{
    public class GetProjectPagingRequest : PagingRequestBase
    {
        public string Keywork { get; set; }
        public string LanguageId { get; set; }

        public int? CategoryId { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
