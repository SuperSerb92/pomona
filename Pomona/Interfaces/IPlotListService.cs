using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Interfaces
{
   public interface IPlotListService
    {
        List<Models.PlotList> GetPlotLists();
        void AddPlot(Models.PlotList plotL);
        void DeletePlot(Models.PlotList plotL);
        void UpdatePlot(Models.PlotList plotL);
        void SaveChanges();
    }
}
