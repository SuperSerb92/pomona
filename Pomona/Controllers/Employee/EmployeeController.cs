using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Pomona.Extensions;
using Pomona.Interfaces;
using Pomona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeesService service;

        private static List<Models.Employee> employees
        {
            get; set;
        }

        //private List<Models.Employee> employees
        //{
        //    get
        //    {
        //        return (Session.AppContext.MemoryCache.Get("EmployeeList_" + Session.AppContext.Id) == null)
        //            ? null : (List<Models.Employee>)(Session.AppContext.MemoryCache.Get("EmployeeList_" + Session.AppContext.Id));
        //    }
        //    set
        //    {
        //        Session.AppContext.MemoryCache.Set("EmployeeList_" + Session.AppContext.Id, value);
        //    }
        //}
        public EmployeeController(IEmployeesService service)
        {
            this.service = service;
        }
        public IActionResult Employee()
        {
            employees = service.GetEmployees();

            return View();
        }

        [HttpGet]
        public object GetEmployees(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(employees, loadOptions);
        }

        [HttpGet]
        public object GetEmployeesStaticList(DataSourceLoadOptions loadOptions)
        {
            employees = service.GetEmployees();

            return DataSourceLoader.Load(employees, loadOptions);
        }


        [HttpPost]
        public IActionResult InsertEmployee(string values)
        {
            var employee = new Models.Employee();
            JsonConvert.PopulateObject(values, employee);

            var employeeExist = employees.Where(o => o.Name == employee.Name && o.MiddleName == employee.MiddleName && o.Surname == employee.Surname).ToList();
            if (employeeExist.Count()>0)
            {
                return StatusCode(500, "Postoji radnik sa istim imenom, prezimenom i srednjim imenom.");
            }
            else
            {
                service.AddEmployee(employee);
                service.SaveChanges();
                RefreshSources();

                return Ok();
            }
          
        }

        [HttpPut]
        public IActionResult UpdateEmployee(int key, string values)
        {
            var employee = employees.FirstOrDefault(a => a.EmployeeID == key);
            if (employee != null)
            {
                JsonConvert.PopulateObject(values, employee);
                service.UpdateEmployee(employee);
                service.SaveChanges();
            }

            RefreshSources();

            return Ok();
        }

        [HttpDelete]
        public void DeleteEmployee(int key)
        {
            var employee = employees.FirstOrDefault(a => a.EmployeeID == key);
            if (employee != null)
            {
                service.DeleteEmployee(employee);
                employees.Remove(employee);
                service.SaveChanges();
            }
        }



        private void RefreshSources()
        {
            employees = service.GetEmployees();
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

        //zasto imamo kes memoriju? 
    }
}


public class ContextMenuItem
{
    public int ID { get; set; }
    public string Name { get; set; }
    public bool BeginGroup { get; set; }
}