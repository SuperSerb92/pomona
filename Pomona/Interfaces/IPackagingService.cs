using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Interfaces
{
  public interface IPackagingService
    {
        List<Models.Packaging> GetPackagings();
        void AddPackaging(Models.Packaging packaging);
        void DeletePackaging(Models.Packaging packaging);
        void UpdatePackaging(Models.Packaging packaging);
        void SaveChanges();
    }
}
