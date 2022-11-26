using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Entities
{
  public  class AboutUs
    {
        public int Id { set; get; }
       
        public string Intro { set; get; }
        public string Founding { set; get; }
      
        public List<AboutUsTranslation> AboutUsTranslations { get; set; }




    }
}
