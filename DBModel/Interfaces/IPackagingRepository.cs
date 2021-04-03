using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Interfaces
{
  public  interface IPackagingRepository
    {
        IEnumerable<Packaging> GetPackaging();
        void Add(DBModel.Models.Packaging packaging);
        void Delete(DBModel.Models.Packaging packaging);
        void Update(DBModel.Models.Packaging packaging);
        void SaveChanges();
    }
}
