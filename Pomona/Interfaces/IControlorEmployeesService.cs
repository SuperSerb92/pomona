using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Interfaces
{
  public  interface IControlorEmployeesService
    {
        List<Models.ControlorEmployeesRelation> GetControlorEmployeeRelations();
        void AddControlorEmployeeRelation(Models.ControlorEmployeesRelation controlorEmployees);
        void DeleteControlorEmployeeRelation(Models.ControlorEmployeesRelation controlorEmployees);
        void UpdateControlorEmployeeRelation(Models.ControlorEmployeesRelation controlorEmployees);
        void RemoveRangeForUser(int userID);
        void SaveChanges();
    }
}
