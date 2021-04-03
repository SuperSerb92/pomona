using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Interfaces
{
  public interface IPlotRepository
    {
        IEnumerable<Plot> GetPlots();
        void Add(DBModel.Models.Plot plot);
        void Delete(DBModel.Models.Plot plot);
        void Update(DBModel.Models.Plot plot);
        void SaveChanges();
    }
}
