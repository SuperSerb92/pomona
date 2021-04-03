using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Interfaces
{
  public  interface ILoginService
    {
        List<Models.User> GetUsers();
        void AddUser(Models.User user);
        void DeleteUser(Models.User user);
        void UpdateUser(Models.User user);
        void SaveChanges();
    }
}
