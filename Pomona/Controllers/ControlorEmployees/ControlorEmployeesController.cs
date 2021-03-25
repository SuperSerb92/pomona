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

    public class ControlorEmployeesController : Controller
    {
        readonly DbModelContext db;

        private List<Pomona.Models.User> allUsers
        {
            get
            {
                return (Session.AppContext.MemoryCache.Get("allUsers_" + Session.AppContext.Id) == null)
                    ? null : (List<Pomona.Models.User>)(Session.AppContext.MemoryCache.Get("allUsers_" + Session.AppContext.Id));
            }
            set
            {
                Session.AppContext.MemoryCache.Set("allUsers_" + Session.AppContext.Id, value);
            }
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


        private List<Pomona.Models.Employee> allEmployees
        {
            get
            {
                return (Session.AppContext.MemoryCache.Get("allEmployees" + Session.AppContext.Id) == null)
                    ? null : (List<Pomona.Models.Employee>)(Session.AppContext.MemoryCache.Get("allEmployees" + Session.AppContext.Id));
            }
            set
            {
                Session.AppContext.MemoryCache.Set("allEmployees" + Session.AppContext.Id, value);
            }
        }

        private List<Pomona.Models.ControlorEmployeesRelation> allRelations
        {
            get
            {
                return (Session.AppContext.MemoryCache.Get("allRelations_" + Session.AppContext.Id) == null)
                    ? null : (List<Pomona.Models.ControlorEmployeesRelation>)(Session.AppContext.MemoryCache.Get("allRelations_" + Session.AppContext.Id));
            }
            set
            {
                Session.AppContext.MemoryCache.Set("allRelations_" + Session.AppContext.Id, value);
            }
        }


        public ControlorEmployeesController(DBModel.DataAccess.DbModelContext db)
        {
            this.db = db;
        }

        public IActionResult ControlorEmployees()
        {
            //todo: uors mapiranje users
            List<DBModel.Models.User> alldbUsers = db.Users.ToList();
            List<DBModel.Models.Employee> alldbEmployees = db.Employees.ToList();
            List<DBModel.Models.ControlorEmployeesRelation> alldbRelations = db.ControlorEmployeesRelations.ToList();
            User user;
            Employee employee;
            ControlorEmployeesRelation relation;
            ControlorEmployeesRelation controlorEmployeesRelation = new ControlorEmployeesRelation();
            allEmployees = new List<Employee>();
            allUsers = new List<User>();
            allRelations = new List<ControlorEmployeesRelation>();
            controlors = new List<User>();

            foreach (var item in alldbEmployees)
            {
                employee = new Employee();
                employee.EmployeeID = item.EmployeeID;
                employee.Name = item.Name;
                employee.Surname = item.Surname;
                allEmployees.Add(employee);
            }
            foreach (var item in alldbUsers)
            {
                user = new User();
                user.UserID = item.UserID;
                user.UserName = item.UserName;
                user.FirstName = item.FirstName;
                user.LastName = item.LastName;
                user.IdGroup = item.IdGroup;
                allUsers.Add(user);
            }
            foreach (var item in alldbRelations)
            {
                relation = new ControlorEmployeesRelation();
                relation.UserID = item.UserID;
                relation.EmployeeID = item.EmployeeID;
                allRelations.Add(relation);
            }
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


            #region test

            //Employee emp = new Employee();
            //emp.EmployeeID = 1;
            //emp.Name = "jokan";
            //emp.Surname = "jokan";
            //emp.PhoneNumber = "342342";
            //emp.Recomendation = "uki";
            //allEmployees.Add(emp);

            //emp = new Employee();
            //emp.EmployeeID = 2;
            //emp.Name = "zokan";
            //emp.Surname = "zokan";
            //emp.PhoneNumber = "342342";
            //emp.Recomendation = "uki";
            //allEmployees.Add(emp);

            //emp = new Employee();
            //emp.EmployeeID = 3;
            //emp.Name = "gican";
            //emp.Surname = "gican";
            //emp.PhoneNumber = "342342";
            //emp.Recomendation = "uki";
            //allEmployees.Add(emp);

            //emp = new Employee();
            //emp.EmployeeID = 4;
            //emp.Name = "uki";
            //emp.Surname = "uki";
            //emp.PhoneNumber = "342342";
            //emp.Recomendation = "uki";
            //allEmployees.Add(emp);

            //emp = new Employee();
            //emp.EmployeeID = 5;
            //emp.Name = "cokan";
            //emp.Surname = "cokan";
            //emp.PhoneNumber = "342342";
            //emp.Recomendation = "uki";
            //allEmployees.Add(emp);

            //ViewData["selectedData"] = allEmployees.Where(x => x.EmployeeID < 3).Select(x=>x.EmployeeID).ToList();
            #endregion


            ViewData["selectedData"] = (from l1 in allEmployees.ToList()
                                        join l2 in allRelations.ToList().Where(x => x.UserID == Session.AppContext.UserID)
                                         on l1.EmployeeID equals l2.EmployeeID
                                        select new { l1.EmployeeID }).ToList();

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

            //  ViewData["selectedData"] = allEmployees.Where(x => x.EmployeeID > 3).Select(x => x.EmployeeID).ToList();

            ViewData["selectedData"] = (from l1 in allEmployees.ToList()
                                        join l2 in allRelations.ToList().Where(x => x.UserID == UserID)
                                         on l1.EmployeeID equals l2.EmployeeID
                                        select new { l1.EmployeeID }).ToList();

            return Json(new { success = true, result = ViewData["selectedData"] });
        }

        //todo mapiranje: kad se sredi mapiranje vratiti na employee kontroler 
        [HttpGet]
        public object GetEmployeesStaticList(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(allEmployees, loadOptions);
        }

        [HttpPost]
        public JsonResult SaveControlorEmployeeRelations(int UserID, List<Employee> employees)
        {
            try
            {
                //todo:uros mapiranje
                DBModel.Models.ControlorEmployeesRelation employeesRelation;

                var deleted = (allRelations.Where(x => x.UserID == UserID)
                                .Select(x => x.EmployeeID).ToList()
                                .Except(employees.Select(x => x.EmployeeID).ToList())).ToList();

                foreach (var item in deleted.ToList())
                {
                    employeesRelation = new DBModel.Models.ControlorEmployeesRelation();
                    employeesRelation.EmployeeID = item;
                    employeesRelation.UserID = UserID;

                    db.ControlorEmployeesRelations.Remove(employeesRelation);
                    db.SaveChanges();
                }

                foreach (var employee in employees)
                {
                    employeesRelation = new DBModel.Models.ControlorEmployeesRelation();
                    var relation = allRelations.Where(x => x.EmployeeID == employee.EmployeeID && x.UserID == UserID).FirstOrDefault();

                    if (relation == null)
                    {
                        employeesRelation.EmployeeID = employee.EmployeeID;
                        employeesRelation.UserID = UserID;

                        db.ControlorEmployeesRelations.Add(employeesRelation);
                        db.SaveChanges();
                    }
                }

                ResetAllRelations();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }

        private void ResetAllRelations()
        {
            try
            {
                //todo uros mapiranje
                allRelations.Clear();
                List<DBModel.Models.ControlorEmployeesRelation> alldbRelations = db.ControlorEmployeesRelations.ToList();
                foreach (var item in alldbRelations)
                {
                    ControlorEmployeesRelation relation = new ControlorEmployeesRelation();
                    relation.UserID = item.UserID;
                    relation.EmployeeID = item.EmployeeID;
                    allRelations.Add(relation);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
