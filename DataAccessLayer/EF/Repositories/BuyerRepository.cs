using DBModel;
using DBModel.Interfaces;
using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.EF.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly DbModelContext _context;
        public BuyerRepository(DbModelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(Buyer buyer)
        {
            _context.Add(buyer);
        }

        public void Delete(Buyer buyer)
        {
            _context.Remove(buyer);
        }

        public IEnumerable<Buyer> GetBuyers()
        {
          return  _context.Buyers.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Buyer buyer)
        {
            _context.Update(buyer);
        }
    }
}
