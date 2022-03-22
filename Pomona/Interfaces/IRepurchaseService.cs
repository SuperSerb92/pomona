using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Interfaces
{
   public interface IRepurchaseService
    {
        List<Models.Repurchase> GetRepurchases();
        void AddRepurchase(Models.Repurchase repurchase);
        void DeleteRepurchase(Models.Repurchase repurchase);
        void UpdateRepurchase(Models.Repurchase repurchase);
        void SaveChanges();
    }
}
