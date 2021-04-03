using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Interfaces
{
   public interface ILoginRepository
    {
        IEnumerable<User> GetUsers();
        void Add(DBModel.Models.User user);
        void Delete(DBModel.Models.User user);
        void Update(DBModel.Models.User user);
        void SaveChanges();
    }
}
