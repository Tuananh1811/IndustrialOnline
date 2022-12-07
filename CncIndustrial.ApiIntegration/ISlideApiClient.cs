using CncIndustrial.ViewModels.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CncIndustrial.ApiIntegration
{
   public interface ISlideApiClient
    {
        Task<List<SlideVm>> GetAll();
    }
}
