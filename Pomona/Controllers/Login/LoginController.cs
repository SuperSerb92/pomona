using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DBModel.DataAccess;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pomona.Models;
using Pomona.Services;

namespace Osa.Unidocs.Web.MetaDesigner.Controllers.Login
{
    public class LoginController : Controller
    {
        readonly DbModelContext db;
        public string username;
        public string password;

        public LoginController(DBModel.DataAccess.DbModelContext db)
        {
            this.db = db;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpGet]
        public object GetGroups(DataSourceLoadOptions loadOptions)
        {
            //todo: uros mapping ovo bi trebalo iz baze da se cita
            Group group = new Group();
            List<Group> list = new List<Group>();
            group.IdGroup = 1;
            group.GroupName = "Vlasnik";
            list.Add(group);

            group = new Group();
            group.IdGroup = 2;
            group.GroupName = "Kontrolor";
            list.Add(group);

            return DataSourceLoader.Load(list, loadOptions);
        }

        [HttpPost]
        public JsonResult Login(User user)
        {
            try
            {
                var login = db.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();

                if (login == null)
                {
                    return Json(new { success = false, result = "Ne postoji korisnik sa unetim podacima" });
                }
                else
                {
                    //Session.CurrentSession.CurrentSessionData = new Session.SessionData();
                    //Session.CurrentSession.CurrentSessionData.UserID = login.UserID;
                    //Session.CurrentSession.CurrentSessionData.UserName = login.UserName;
                    //Session.CurrentSession.CurrentSessionData.SessionID = Session.AppContext.Id;

                    return Json(new { success = true, result = Session.AppContext.Id });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult CreateAccount(User user)
        {
            try
            {
                if (Duplicate(user.UserName))
                {
                    return Json(new { success = false, result = "Već postoji registrovan korisnik sa unetim korisničkim imenom" });
                }
                else
                {
                    //todo :uros mapiranje 
                    DBModel.Models.User dbUser = new DBModel.Models.User();
                    dbUser.UserName = user.UserName;
                    dbUser.Password = user.Password;
                    dbUser.RepeatedPassword = user.RepeatedPassword;
                    dbUser.FarmName = user.FarmName;
                    dbUser.FarmNo = user.FarmNo;
                    dbUser.Email = user.Email;
                    db.Add(dbUser);
                    db.SaveChanges();

                    return Json(new { success = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }

        private bool Duplicate(string username)
        {
            return db.Users.Any(x => x.UserName.ToUpper().Trim() == username.ToUpper().Trim());
        }


    }
}
