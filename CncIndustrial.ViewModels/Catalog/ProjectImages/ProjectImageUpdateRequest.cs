using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CncIndustrial.ViewModels.Catalog.ProjectImages
{
    public class ProjectImageUpdateRequest
    {
        public int Id { get; set; }

        public string Caption { get; set; }

        public bool IsDefault { get; set; }

        public int SortOrder { get; set; }

        public string LanguageId { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
