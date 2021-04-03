using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Interfaces
{
  public interface IBuyerService
    {
        List<Models.Buyer> GetBuyers();
        void AddBuyer(Models.Buyer buyer);
        void DeleteBuyer(Models.Buyer buyer);
        void UpdateBuyer(Models.Buyer buyer);
        void SaveChanges();
    }
}
