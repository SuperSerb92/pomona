using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Interfaces
{
   public interface ICultureTypeRepository
    {
        IEnumerable<CultureType> GetCultureTypes();
        void Add(DBModel.Models.CultureType cultureType);
        void Delete(DBModel.Models.CultureType cultureType);
        void Update(DBModel.Models.CultureType cultureType);
        void SaveChanges();
    }
}
