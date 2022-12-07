using CncIndustrial.ViewModels.Catalog.Project;
using CncIndustrial.ViewModels.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNCIndustrial.WebApp.Models
{
    public class HomeViewModel
    {
        public List<SlideVm> Slides { get; set; }

        public List<ProductVm> FeaturedProducts { get; set; }

        public List<ProductVm> LatestProducts { get; set; }
    }
}
