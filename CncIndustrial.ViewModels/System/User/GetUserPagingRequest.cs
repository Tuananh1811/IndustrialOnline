using CncIndustrial.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CncIndustrial.ViewModels.System.User
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
