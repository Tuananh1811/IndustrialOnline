using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Entities
{
   public class NewsTranslation
    {
        public int Id { set; get; }
        public int NewsId { set; get; }
        public string Title { set; get; }
        public string Content { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string LanguageId { set; get; }
        public string SeoAlias { set; get; }

        public News News { get; set; }

        public Language Language { get; set; }
    }
}
