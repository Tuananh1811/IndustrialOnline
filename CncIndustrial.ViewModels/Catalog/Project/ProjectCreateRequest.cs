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
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }

        public bool? IsFeatured { get; set; }
        public string iframeMap { set; get; }
        public IFormFile ThumbnailImage { get; set; }

    }
}
