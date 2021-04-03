using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Interfaces
{
   public interface IGroupRepository
    {
        IEnumerable<Group> GetGroups();
        void Add(DBModel.Models.Group group);
        void Delete(DBModel.Models.Group group);
        void Update(DBModel.Models.Group group);
        void SaveChanges();
    }
}
