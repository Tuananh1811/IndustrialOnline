using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CncIndustrial.ViewModels.Catalog.Project
{
    public class ProjectCreateRequest
    {


        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập tên dự án")]
        public string Name { set; get; }

        public string Description { set; get; }
       
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }

        public string LanguageId { set; get; }

        public bool? IsFeatured { get; set; }

        public string iframeMap { set; get; }

        public string TotalArea { set; get; }

        public string VacantArea { set; get; }

        public string Area { get; set; }

        public string Location { get; set; }

        public string MainFunction1 { set; get; }

        public string MainFunction2 { set; get; }

        public string MainFunction3 { set; get; }

        public string MainFunction4 { set; get; }

        public string Summary { set; get; }

        public string AccessibilityCenter { get; set; }

        public string AccessibilityPort { get; set; }

        public string AccessibilityAirport { get; set; }

        public string AccessibilityExpressway { get; set; }

        public string Commerce { get; set; }

        public string Technical { get; set; }

      
        public IFormFile ThumbnailImage { get; set; }

    }
}
