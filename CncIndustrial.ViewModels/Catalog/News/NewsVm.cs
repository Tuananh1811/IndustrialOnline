using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CncIndustrial.ViewModels.Catalog.News
{
   public class NewsVm
    {
        public int Id { set; get; }

        public string Title { get; set; }

        public string DescriShort { get; set; }

        public string SeoDescription { set; get; }

        public string SeoTitle { set; get; }

        public string LanguageId { set; get; }

        public string SeoAlias { set; get; }

        public DateTime? NgayTao { get; set; }

        public string HinhAnhMinhHoa { get; set; }
    }
}
