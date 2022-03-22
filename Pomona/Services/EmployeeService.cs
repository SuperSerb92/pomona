using AutoMapper;
using DBModel.Interfaces;
using Pomona.Interfaces;
using Pomona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Services
{
    public class EmployeeService : IEmployeesService
    {
        private readonly IEmployeeRepostitory employeeRepository;
        private readonly IMapper mapper;
        public EmployeeService(IEmployeeRepostitory employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        public void AddEmployee(Employee employee)
        {
            var employeeDB = mapper.Map<DBModel.Models.Employee>(employee);
            employeeRepository.Add(employeeDB);
            //SaveChanges
        }

        public void DeleteEmployee(Models.Employee employee)
        {
            var employeeDB = mapper.Map<DBModel.Models.Employee>(employee);
            employeeRepository.Delete(employeeDB);
        }


        public List<Employee> GetEmployees()
        {
            var employees = employeeRepository.GetEmployees();
            var employeesDto = mapper.Map<IEnumerable<Models.Employee>>(employees);
            return employeesDto.OrderBy(x => x.EmployeeID).ToList();
        }

        public void SaveChanges()
        {
           employeeRepository.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            var employeeDB = mapper.Map<DBModel.Models.Employee>(employee);
            employeeRepository.Update(employeeDB);
        }
    }
}
