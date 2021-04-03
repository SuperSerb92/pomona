using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBModel;
using DBModel.Interfaces;
using DBModel.Models;

namespace DataAccessLayer.EF.Repositories
{
    public class PlotRepository : IPlotRepository
    {
        private readonly DbModelContext _context;
        public PlotRepository(DbModelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(Plot plot)
        {
           _context.Add(plot);
        }

        public void Delete(Plot plot)
        {
           _context.Remove(plot);
        }

        public IEnumerable<Plot> GetPlots()
        {
            return _context.Plots.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Plot plot)
        {
          _context.Update(plot);
        }
    }
}
