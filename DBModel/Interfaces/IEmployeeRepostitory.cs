using DBModel.Models;
using System.Collections.Generic;

namespace DBModel.Interfaces
{
    public interface IEmployeeRepostitory
    {
        IEnumerable<Employee> GetEmployees();
        void Add(DBModel.Models.Employee employee);
        void Delete(DBModel.Models.Employee employee);
        void Update(DBModel.Models.Employee employee);
        void SaveChanges();
    }
}
