using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Interfaces
{
   public interface IGroupService
    {
        List<Models.Group> GetGroups();
        void AddGroup(Models.Group group);
        void DeleteGroup(Models.Group group);
        void UpdateGroup(Models.Group group);
        void SaveChanges();
    }
}
