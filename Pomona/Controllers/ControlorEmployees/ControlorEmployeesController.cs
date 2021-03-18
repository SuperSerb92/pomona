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

        private List<DBModel.Models.User> allUsers
        {
            get
            {
                return (Session.AppContext.MemoryCache.Get("allUsers_" + Session.AppContext.Id) == null)
                    ? null : (List<DBModel.Models.User>)(Session.AppContext.MemoryCache.Get("allUsers_" + Session.AppContext.Id));
            }
            set
            {
                Session.AppContext.MemoryCache.Set("allUsers_" + Session.AppContext.Id, value);
            }
        }

        private DBModel.Models.User loggedUser
        {
            get
            {
                return (Session.AppContext.MemoryCache.Get("loggedUser_" + Session.AppContext.Id) == null)
                    ? null : (DBModel.Models.User)(Session.AppContext.MemoryCache.Get("loggedUser_" + Session.AppContext.Id));
            }
            set
            {
                Session.AppContext.MemoryCache.Set("loggedUsers_" + Session.AppContext.Id, value);
            }
        }

        private List<DBModel.Models.User> controlors
        {
            get
            {
                return (Session.AppContext.MemoryCache.Get("allControlors_" + Session.AppContext.Id) == null)
                    ? null : (List<DBModel.Models.User>)(Session.AppContext.MemoryCache.Get("allControlors_" + Session.AppContext.Id));
            }
            set
            {
                Session.AppContext.MemoryCache.Set("allControlors_" + Session.AppContext.Id, value);
            }
        }

        public ControlorEmployeesController(DBModel.DataAccess.DbModelContext db)
        {
            this.db = db;
        }

        public IActionResult ControlorEmployees()
        {

            //todo: uors mapiranje
            List<DBModel.Models.User> allUsers = db.Users.ToList();

            //ViewData["selectedData"] = from l1 in db.Employees.ToList()
            //                           join l2 in db.ControlorEmployeesRelations.ToList().Where(x => x.UserID == Session.AppContext.UserID)
            //                            on l1.EmployeeID equals l2.EmployeeID
            //                           select new { l1 };

            ViewData["selectedData"] = db.Employees.ToList().Where(x => x.EmployeeID == 3).FirstOrDefault();

            var  loggedUser = allUsers.Where(x => x.UserID == Session.AppContext.UserID).FirstOrDefault();

            if (loggedUser.IdGroup == 1)
                controlors = allUsers.Where(x => x.IdGroup == 2).ToList();
            else
                controlors.Add(loggedUser);

            return View();
        }
       
        [HttpGet]
        public object GetControlors(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(controlors, loadOptions);
        }
        [HttpPost]
        public JsonResult GetSelectedData(int UserID)
        {
           
            ViewData["selectedData"] = db.Employees.ToList().Where(x => x.EmployeeID == 3).FirstOrDefault();
            return Json(new { success = true });
        }
    }
}
