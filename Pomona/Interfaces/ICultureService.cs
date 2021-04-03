using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Interfaces
{
  public interface ICultureService
    {
        List<Models.Culture> GetCultures();
        void AddCulture(Models.Culture culture);
        void DeleteCulture(Models.Culture culture);
        void UpdateCulture(Models.Culture culture);
        void SaveChanges();
    }
}
