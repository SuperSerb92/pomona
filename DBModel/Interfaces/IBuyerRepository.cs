using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Interfaces
{
   public interface IBuyerRepository
    {
        IEnumerable<Buyer> GetBuyers();
        void Add(DBModel.Models.Buyer buyer);
        void Delete(DBModel.Models.Buyer buyer);
        void Update(DBModel.Models.Buyer buyer);
        void SaveChanges();
    }
}
