using CncIndustrial.ViewModels.Catalog.Categories;
using CncIndustrial.ViewModels.Catalog.ProductImages;
using CncIndustrial.ViewModels.Catalog.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNCIndustrial.WebApp.Models
{
    public class ProductDetailViewModel
    {
        public CategoryVm Category { get; set; }

        public ProductVm Product { get; set; }

        public List<ProductVm> RelatedProducts { get; set; }

        public List<ProjectImageViewModel> ProductImages { get; set; }
    }
}
