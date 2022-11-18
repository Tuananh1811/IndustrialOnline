using System;
using System.Collections.Generic;
using System.Text;

namespace CncIndustrial.ViewModels.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { set; get; }
        public int TotalRecord { set; get; }
    }
}
