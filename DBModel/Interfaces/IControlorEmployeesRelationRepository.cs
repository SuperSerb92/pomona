using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Interfaces
{
   public interface IControlorEmployeesRelationRepository
    {
        IEnumerable<ControlorEmployeesRelation> GetConEmployeesRelations();
        void Add(DBModel.Models.ControlorEmployeesRelation relation);
        void Delete(DBModel.Models.ControlorEmployeesRelation relation);
        void Update(DBModel.Models.ControlorEmployeesRelation relation);
        void SaveChanges();
        void RemoveRangeForUser(int userID);
    }
}
