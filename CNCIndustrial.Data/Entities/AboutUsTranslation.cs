using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Entities
{
   public class AboutUsTranslation
    {
        public int Id { set; get; }
        public int AboutUsId { set; get; }
        public string Intro { set; get; }
        public string Founding { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string LanguageId { set; get; }
        public string SeoAlias { set; get; }

        public AboutUs AboutUs { get; set; }
       
        public Language Language { get; set; }
       
    }
}
