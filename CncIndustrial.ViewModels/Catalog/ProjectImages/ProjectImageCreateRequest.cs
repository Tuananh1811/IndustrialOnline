using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CncIndustrial.ViewModels.Catalog.ProjectImages
{
    public class ProjectImageCreateRequest
    {
        public string Caption { get; set; }

        public bool IsDefault { get; set; }

        public int SortOrder { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
