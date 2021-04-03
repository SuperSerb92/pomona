using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Interfaces
{
   public interface ICultureRepository
    {
        IEnumerable<Culture> GetCultures();
        void Add(DBModel.Models.Culture culture);
        void Delete(DBModel.Models.Culture culture);
        void Update(DBModel.Models.Culture culture);
        void SaveChanges();
    }
}
