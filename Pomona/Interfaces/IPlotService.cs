using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Interfaces
{
   public interface IPlotService
    {
        List<Models.Plot> GetPlots();
        void AddPlot(Models.Plot plot);
        void DeletePlot(Models.Plot plot);
        void UpdatePlot(Models.Plot plot);
        void SaveChanges();
    }
}
