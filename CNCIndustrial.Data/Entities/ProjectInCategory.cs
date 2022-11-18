using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Entities
{
    public class ProjectInCategory
    {
        public int ProjectId { get; set; }

        public ProjectLocation Project { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
