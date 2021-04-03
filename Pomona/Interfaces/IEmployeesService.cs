using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Interfaces
{
   public interface IEmployeesService
    {
        List<Models.Employee> GetEmployees();
        void AddEmployee(Models.Employee employee);
        void DeleteEmployee(Models.Employee employee);
        void UpdateEmployee(Models.Employee employee);
        void SaveChanges();
    }
}
