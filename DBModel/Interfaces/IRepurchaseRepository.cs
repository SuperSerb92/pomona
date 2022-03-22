using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Interfaces
{
   public interface IRepurchaseRepository
    {
        IEnumerable<Repurchase> GetRepurchases();
        void Add(DBModel.Models.Repurchase repurchase);
        void Delete(DBModel.Models.Repurchase repurchase);
        void Update(DBModel.Models.Repurchase repurchase);
        void SaveChanges();
    }
}
