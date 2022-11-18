using System;
using System.Collections.Generic;
using System.Text;

namespace CncIndustrial.ViewModels.Catalog.ProductImages
{
    public class ProjectImageViewModel
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string ImagePath { get; set; }

        public string Caption { get; set; }

        public bool IsDefault { get; set; }

        public DateTime DateCreated { get; set; }

        public int SortOrder { get; set; }

        public long FileSize { get; set; }
    }
}
