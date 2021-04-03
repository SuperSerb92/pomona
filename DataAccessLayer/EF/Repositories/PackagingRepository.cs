using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBModel;
using DBModel.Interfaces;
using DBModel.Models;

namespace DataAccessLayer.EF.Repositories
{
    public class PackagingRepository : IPackagingRepository
    {
        private readonly DbModelContext _context;
        public PackagingRepository(DbModelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(Packaging packaging)
        {
           _context.Add(packaging);
        }

        public void Delete(Packaging packaging)
        {
            _context.Remove(packaging);
        }

        public IEnumerable<Packaging> GetPackaging()
        {
          return _context.Packagings.ToList();
        }

        public void SaveChanges()
        {
           _context.SaveChanges();
        }

        public void Update(Packaging packaging)
        {
            _context.Update(packaging);
        }
    }
}
