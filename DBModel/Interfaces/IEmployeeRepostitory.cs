using DBModel.Models;
using System.Collections.Generic;

namespace DBModel.Interfaces
{
    public interface IEmployeeRepostitory
    {
        IEnumerable<Employee> GetEmployees();
    }
}
