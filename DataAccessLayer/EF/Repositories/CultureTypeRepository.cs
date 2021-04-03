using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBModel;
using DBModel.Interfaces;
using DBModel.Models;

namespace DataAccessLayer.EF.Repositories
{
  public  class CultureTypeRepository: ICultureTypeRepository
    {
        private readonly DbModelContext _context;
        public CultureTypeRepository(DbModelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(CultureType culture)
        {
            _context.Add(culture);
        }

        public void Delete(CultureType culture)
        {
            _context.Remove(culture);
        }

        public IEnumerable<CultureType> GetCultureTypes()
        {
            return _context.CultureTypes.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(CultureType culture)
        {
            _context.Update(culture);
        }
    }
}
