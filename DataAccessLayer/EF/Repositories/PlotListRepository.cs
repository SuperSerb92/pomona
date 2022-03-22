using DBModel;
using DBModel.Interfaces;
using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.EF.Repositories
{
   public class PlotListRepository: IPlotListRepository
    {
        private readonly DbModelContext _context;
        public PlotListRepository(DbModelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(PlotList plotL)
        {
            _context.Add(plotL);
        }

        public void Delete(PlotList plotL)
        {
            _context.Remove(plotL);
        }

        public IEnumerable<PlotList> GetPlotLists()
        {
            return _context.PlotList.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(PlotList plotL)
        {
            _context.Update(plotL);
        }
    }
}
