using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Entities
{
   public class Language
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public List<ProjectTranslation> ProjectTranslations { get; set; }

        public List<CategoryTranslation> CategoryTranslations { get; set; }

        public List<NewsTranslation> NewsTranslations { get; set; }

        public List<AboutUsTranslation> AboutUsTranslations { get; set; }

        public List<EmployeeTranslation> EmployeeTranslations { get; set; }



    }
}
