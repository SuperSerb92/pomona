using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Interfaces
{
   public interface ICultureTypeService
    {
        List<Models.CultureType> GetCultureTypes();
        void AddCultureType(Models.CultureType cultureType);
        void DeleteCultureType(Models.CultureType cultureType);
        void UpdateCultureType(Models.CultureType cultureType);
        void SaveChanges();
    }
}
