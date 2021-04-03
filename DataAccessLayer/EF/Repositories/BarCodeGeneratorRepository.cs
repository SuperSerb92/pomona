using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBModel;
using DBModel.Interfaces;
using DBModel.Models;

namespace DataAccessLayer.EF.Repositories
{
    public class BarCodeGeneratorRepository : IBarCodeGeneratorRepository
    {
        private readonly DbModelContext _context;
        public BarCodeGeneratorRepository(DbModelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(BarCodeGenerator barCode)
        {
           _context.Add(barCode);
        }

        public void Delete(BarCodeGenerator barCode)
        {
            _context.Remove(barCode);
        }

        public IEnumerable<BarCodeGenerator> GetBarCodeGenerators()
        {
            return _context.BarCodeGenerators.ToList();
        }

        public void SaveChanges()
        {
           _context.SaveChanges();
        }

        public void Update(BarCodeGenerator barCode)
        {
            _context.Update(barCode);
        }
    }
}
