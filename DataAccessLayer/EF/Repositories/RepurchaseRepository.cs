using DBModel;
using DBModel.Interfaces;
using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.EF.Repositories
{
    public class RepurchaseRepository : IRepurchaseRepository
    {
        private readonly DbModelContext _context;
        public RepurchaseRepository(DbModelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public void Add(Repurchase repurchase)
        {
            _context.Add(repurchase);
        }

        public void Delete(Repurchase repurchase)
        {
            _context.Remove(repurchase);
        }

        public IEnumerable<Repurchase> GetRepurchases()
        {
            return _context.Repurchases.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Repurchase repurchase)
        {
            _context.Update(repurchase);
        }
    }
}
