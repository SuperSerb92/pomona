using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Interfaces
{
  public  interface IPlotListRepository
    {
        IEnumerable<PlotList> GetPlotLists();
        void Add(DBModel.Models.PlotList plotL);
        void Delete(DBModel.Models.PlotList plotL);
        void Update(DBModel.Models.PlotList plotL);
        void SaveChanges();
    }
}
