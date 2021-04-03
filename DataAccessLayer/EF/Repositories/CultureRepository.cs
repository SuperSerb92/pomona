using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBModel;
using DBModel.Interfaces;
using DBModel.Models;

namespace DataAccessLayer.EF.Repositories
{
    public class CultureRepository : ICultureRepository
    {
        private readonly DbModelContext _context;
        public CultureRepository(DbModelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(Culture culture)
        {
            _context.Add(culture);
        }

        public void Delete(Culture culture)
        {
            _context.Remove(culture);
        }

        public IEnumerable<Culture> GetCultures()
        {
           return _context.Cultures.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Culture culture)
        {
            _context.Update(culture);
        }
    }
}
