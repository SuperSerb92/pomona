using DBModel.DataAccess;
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
        readonly DbModelContext db;
        private List<DBModel.Models.Employee> employees
        {
            get
            {
                return (Session.AppContext.MemoryCache.Get("EmployeeList_" + Session.AppContext.Id) == null)
                    ? null : (List<DBModel.Models.Employee>)(Session.AppContext.MemoryCache.Get("EmployeeList_" + Session.AppContext.Id));
            }
            set
            {
                Session.AppContext.MemoryCache.Set("EmployeeList_" + Session.AppContext.Id, value);
            }
        }
        public EmployeeController(DBModel.DataAccess.DbModelContext db)
        {
            this.db = db;
        }
        public IActionResult Employee()
        {
            employees = db.Employees.ToList();
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
            employees = db.Employees.ToList();

            return DataSourceLoader.Load(employees, loadOptions);
        }


        [HttpPost]
        public IActionResult InsertEmployee(string values)
        {          
            var employee = new DBModel.Models.Employee();
            JsonConvert.PopulateObject(values, employee);  
            
            //todo: pitaj coku jel hocemo insert u prvi red  ili poslednji ovo ispod je insert na prvo mesto
            //employees.Insert(0, employee);
            
            employees.Add(employee);
            db.Add(employee);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateEmployee(int key, string values)
        {
            var employee = employees.FirstOrDefault(a => a.EmployeeID == key);
            JsonConvert.PopulateObject(values, employee);

            db.Update(employee);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public void DeleteEmployee(int key)
        {
            //todo: kad je spusten kljuc ne sme se brisati?
            
            var employee = employees.FirstOrDefault(a => a.EmployeeID == key);
            db.Remove(employee);
            db.SaveChanges();
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