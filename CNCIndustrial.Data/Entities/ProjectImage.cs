using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Entities
{
   public class ProjectImage
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string ImagePath { get; set; }

        public string Caption { get; set; } //alt

        public bool IsDefault { get; set; }

        public DateTime DateCreated { get; set; }

        public int SortOrder { get; set; }

        public long FileSize { get; set; }

        public ProjectLocation Project { get; set; }
        public News News { set; get; }
        public AboutUs AboutUs { set; get; }
    }
}
