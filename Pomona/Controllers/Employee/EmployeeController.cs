using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Pomona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Controllers
{
    public class EmployeeController : Controller
    {

        private List<Employee> employees
        {
            get
            {
                return (Session.AppContext.MemoryCache.Get("EmployeeList_" + Session.AppContext.Id) == null)
                    ? null : ( List<Employee>)(Session.AppContext.MemoryCache.Get("EmployeeList_" + Session.AppContext.Id));
            }
            set
            {
                Session.AppContext.MemoryCache.Set("EmployeeList_" + Session.AppContext.Id, value);
            }
        }
        public EmployeeController()
        {
            
        }
        public IActionResult Employee()
        {
            //todo database get all employees from db
            // employees =  
            employees = new List<Employee>();
            return View();
        }

        [HttpGet]
        public object GetEmployees(DataSourceLoadOptions loadOptions)
        {           
            return DataSourceLoader.Load(employees, loadOptions);
        }


        [HttpPost]
        public IActionResult InsertEmployee(string values)
        {
            var employee = new Employee();
            JsonConvert.PopulateObject(values, employee);
            employee.EmployeeID = (employees.Count == 0 ? 1 : employees.Max(x => x.EmployeeID) + 1);
            employees.Insert(0, employee);
            //todo database insert 
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateEmployee(int key, string values)
        {
            var employee = employees.FirstOrDefault(a => a.EmployeeID == key);
            JsonConvert.PopulateObject(values, employee);
            //todo database update 
            return Ok();
        }

        [HttpDelete]
        public void DeleteEmployee(int key)
        {
            var employee = employees.FirstOrDefault(a =>a.EmployeeID == key);
            //todo database delete
            employees.Remove(employee);
          
        }
        [HttpGet]
        public JsonResult GetEmployeesContextMenuItems()
        {
            List<ContextMenuItem> dcContextMenuItems = new List<ContextMenuItem>();
         
                ContextMenuItem dcContextMenuItem = new ContextMenuItem();
                dcContextMenuItem.ID = 1;
                dcContextMenuItem.Name = "!P! Novi";
                dcContextMenuItem.BeginGroup = false;
                dcContextMenuItems.Add(dcContextMenuItem);

                dcContextMenuItem = new ContextMenuItem();
                dcContextMenuItem.ID = 1;
                dcContextMenuItem.Name = "!P! Novi";
                dcContextMenuItem.BeginGroup = false;
                dcContextMenuItems.Add(dcContextMenuItem);

                dcContextMenuItem = new ContextMenuItem();
                dcContextMenuItem.ID = 1;
                dcContextMenuItem.Name = "!P! Novi";
                dcContextMenuItem.BeginGroup = false;
                dcContextMenuItems.Add(dcContextMenuItem);

           
                return Json(new { success = false, result = dcContextMenuItems });
            }
           
        
    }
}


public class ContextMenuItem
{
    public int ID { get; set; }
    public string Name { get; set; }
    public bool BeginGroup { get; set; }
}