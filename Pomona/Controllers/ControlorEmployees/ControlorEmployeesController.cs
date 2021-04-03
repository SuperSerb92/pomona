
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Pomona.Interfaces;
using Pomona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Controllers
{

    public class ControlorEmployeesController : Controller
    {

        IControlorEmployeesService service;
        ILoginService loginService;
        IEmployeesService employeesService;

       

        private static List<Pomona.Models.User> allUsers
        {
            get; set;
        }

        private static List<Pomona.Models.Employee> allEmployees
        {
            get; set;
        }

        private static List<Pomona.Models.ControlorEmployeesRelation> allRelations
        {
            get; set;           
        }
        private Pomona.Models.User loggedUser
        {
            get
            {
                return (Session.AppContext.MemoryCache.Get("loggedUser_" + Session.AppContext.Id) == null)
                    ? null : (Pomona.Models.User)(Session.AppContext.MemoryCache.Get("loggedUser_" + Session.AppContext.Id));
            }
            set
            {
                Session.AppContext.MemoryCache.Set("loggedUsers_" + Session.AppContext.Id, value);
            }
        }

        private List<Pomona.Models.User> controlors
        {
            get
            {
                return (Session.AppContext.MemoryCache.Get("allControlors_" + Session.AppContext.Id) == null)
                    ? null : (List<Pomona.Models.User>)(Session.AppContext.MemoryCache.Get("allControlors_" + Session.AppContext.Id));
            }
            set
            {
                Session.AppContext.MemoryCache.Set("allControlors_" + Session.AppContext.Id, value);
            }
        }



        //private List<Pomona.Models.Employee> allEmployees
        //{
        //    get
        //    {
        //        return (Session.AppContext.MemoryCache.Get("allEmployees" + Session.AppContext.Id) == null)
        //            ? null : (List<Pomona.Models.Employee>)(Session.AppContext.MemoryCache.Get("allEmployees" + Session.AppContext.Id));
        //    }
        //    set
        //    {
        //        Session.AppContext.MemoryCache.Set("allEmployees" + Session.AppContext.Id, value);
        //    }
        //}

     


        public ControlorEmployeesController(IControlorEmployeesService service,ILoginService loginService,IEmployeesService employeesService)
        {
            this.service = service;
            this.employeesService = employeesService;
            this.loginService = loginService;            
        }
        
        public IActionResult ControlorEmployees()
        {       
            ControlorEmployeesRelation controlorEmployeesRelation = new ControlorEmployeesRelation();
            allEmployees = employeesService.GetEmployees();
            allUsers = loginService.GetUsers();
            allRelations = service.GetControlorEmployeeRelations();
            controlors = new List<User>();

            var loggedUser = allUsers.Where(x => x.UserID == Session.AppContext.UserID).FirstOrDefault();

            if (loggedUser.IdGroup == 1)
            {
                controlors = allUsers.Where(x => x.IdGroup == 2).ToList();
            }
            else
            {
                controlorEmployeesRelation.UserID = loggedUser.UserID;
                controlors.Add(loggedUser);
            }

            return View(controlorEmployeesRelation);
        }

        [HttpGet]
        public object GetControlors(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(controlors, loadOptions);
        }

        [HttpGet]
        public JsonResult GetSelectedData(int UserID)
        {
            ViewData["selectedData"] = allRelations.Where(x => x.UserID == UserID).Select(x => x.EmployeeID).ToList();

            //ViewData["selectedData"] = (from l1 in allEmployees.ToList()
            //                            join l2 in allRelations.ToList().Where(x => x.UserID == UserID)
            //                             on l1.EmployeeID equals l2.EmployeeID
            //                            select new { l1.EmployeeID }).ToList();

            return Json(new { success = true, result = ViewData["selectedData"] });
        }

        ////todo mapiranje: kad se sredi mapiranje vratiti na employee kontroler 
        //[HttpGet]
        //public object GetEmployeesStaticList(DataSourceLoadOptions loadOptions)
        //{
        //    return DataSourceLoader.Load(allEmployees, loadOptions);
        //}

        [HttpPost]
        public JsonResult SaveControlorEmployeeRelations(int UserID, List<Employee> employees)
        {
            try
            {
                ControlorEmployeesRelation employeesRelation;                   
                service.RemoveRangeForUser(UserID);              
             //   service.SaveChanges();

                foreach (var employee in employees)
                {
                    employeesRelation = new ControlorEmployeesRelation();
                    employeesRelation.EmployeeID = employee.EmployeeID;
                    employeesRelation.UserID = UserID;

                    service.AddControlorEmployeeRelation(employeesRelation);
                    //service.SaveChanges();
                }

                service.SaveChanges();

                //    ControlorEmployeesRelation employeesRelation;

                //    var deleted = (allRelations.Where(x => x.UserID == UserID)
                //                    .Select(x => x.EmployeeID).ToList()
                //                    .Except(employees.Select(x => x.EmployeeID).ToList())).ToList();

                //    foreach (var item in deleted.ToList())
                //    {
                //        employeesRelation = new ControlorEmployeesRelation();
                //        employeesRelation.EmployeeID = item;
                //        employeesRelation.UserID = UserID;

                //        service.DeleteControlorEmployeeRelation(employeesRelation);
                //        service.SaveChanges();
                //    }

                //    foreach (var employee in employees)
                //    {
                //        employeesRelation = new ControlorEmployeesRelation();
                //        var relation = allRelations.Where(x => x.EmployeeID == employee.EmployeeID && x.UserID == UserID).FirstOrDefault();

                //        if (relation == null)
                //        {
                //            employeesRelation.EmployeeID = employee.EmployeeID;
                //            employeesRelation.UserID = UserID;

                //            service.AddControlorEmployeeRelation(employeesRelation);
                //            service.SaveChanges();
                //        }
                //    }

                RefreshSources();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }

        private void RefreshSources()
        {
            try
            {
                allRelations.Clear();
                allRelations = service.GetControlorEmployeeRelations();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
