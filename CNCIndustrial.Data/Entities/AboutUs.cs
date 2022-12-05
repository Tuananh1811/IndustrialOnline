using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Entities
{
  public  class AboutUs
    {
        public int Id { set; get; }
     
        public string ImageBanner { get; set; }

        public string ImageFly { get; set; }

        public List<AboutUsTranslation> AboutUsTranslations { get; set; }

    }
}
