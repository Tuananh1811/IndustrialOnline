using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Entities
{
  public  class ProjectLocation
    {
        public int Id { set; get; }

        public decimal Price { set; get; }

        public decimal OriginalPrice { set; get; }

        public int Stock { set; get; }

        public int ViewCount { set; get; }

        public string iframeMap { set; get; }

        public DateTime DateCreated { set; get; }

        public bool? IsFeatured { get; set; }

        public List<ProjectInCategory> ProductInCategories { get; set; }

        public List<ProjectImage> ProjectImages { get; set; }

        public List<ProjectTranslation> ProjectTranslations { get; set; }


    }
}
