using DBModel;
using DBModel.Interfaces;
using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EF.Repositories
{
    public class EmployeeRepository : IEmployeeRepostitory
    {
        private readonly DbModelContext _context;
        public EmployeeRepository(DbModelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Employee employee)
        {
            _context.Add(employee);
        }

        public void Delete(Employee employee)
        {
          
            _context.Remove(employee);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _context.Update(employee);
        }
    }
}
