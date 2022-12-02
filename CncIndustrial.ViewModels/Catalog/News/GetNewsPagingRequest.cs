using CncIndustrial.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CncIndustrial.ViewModels.Catalog.News
{
  public  class GetNewsPagingRequest : PagingRequestBase
    {
        public string LanguageId { get; set; }
       

    }
}
