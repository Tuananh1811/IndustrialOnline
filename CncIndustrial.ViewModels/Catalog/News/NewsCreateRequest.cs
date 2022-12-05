using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CncIndustrial.ViewModels.Catalog.News
{
   public class NewsCreateRequest
    {

        public string Title { get; set; }

        public string DescriShort { get; set; }

        public string Content { set; get; }

        public string SeoDescription { set; get; }

        public string SeoTitle { set; get; }

        public string LanguageId { set; get; }

        public string SeoAlias { set; get; }

        public IFormFile HinhAnhMinhHoa { get; set; }

    }
}
