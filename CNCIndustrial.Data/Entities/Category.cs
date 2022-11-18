using CNCIndustrial.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Entities
{
   public class Category
    {
        public int Id { set; get; }
        public int SortOrder { set; get; }
        public bool IsShowOnHome { set; get; }
        public int? ParentId { set; get; }
        public Status Status { set; get; }

        public List<ProjectInCategory> ProjectInCategories { get; set; }

        public List<CategoryTranslation> CategoryTranslations { get; set; }
    }
}
