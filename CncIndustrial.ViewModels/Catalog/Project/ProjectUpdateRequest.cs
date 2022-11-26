using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CncIndustrial.ViewModels.Catalog.Project
{
    public class ProjectUpdateRequest
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public string Description { set; get; }

        public string Details { set; get; }

        public string SeoDescription { set; get; }

        public string SeoTitle { set; get; }

        public string TotalArea { set; get; }

        public string VacantArea { set; get; }

        public string Investor { set; get; }

        public string SeoAlias { get; set; }

        public string LanguageId { set; get; }

        public string MainFunction1 { set; get; }

        public string MainFunction2 { set; get; }

        public string MainFunction3 { set; get; }

        public string MainFunction4 { set; get; }

        public string Summary { set; get; }
        public IFormFile ThumbnailImage { get; set; }

    }
}
