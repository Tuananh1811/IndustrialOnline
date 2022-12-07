using CncIndustrial.ViewModels.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CNCIndustrial.Application.Slides
{
   public interface ISlideService
    {
        Task<List<SlideVm>> GetAll();
    }
}
