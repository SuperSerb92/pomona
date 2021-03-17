using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
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
                var login = db.Users.Where(x => x.UserName == user.UserName).FirstOrDefault();

                if (login == null)
                {
                    return Json(new { success = false, result = "Ne postoji korisnik sa unetim korisničkim imenom" });
                }
                else if (login.Password != user.Password)
                {
                    return Json(new { success = false, result = "Neispravna lozinka" });
                }
                else if (login.IndLogged == 1)
                {
                    return Json(new { success = false, result = "Uneti korisnik je već ulogovan" });
                }
                else
                {
                    // byte[] bytes = Encoding.UTF8.GetBytes(login.UserName);
                    //  LoginUser(login.UserID);
                    return Json(new { success = true, result = Session.AppContext.sessionID, user = login.UserID }); ;
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }

        //private void LoginUser(int userID)
        //{
        //    var user = db.Users.Where(x => x.UserID == userID).FirstOrDefault();
        //    if (user != null)
        //    {
        //        user.IndLogged = 1;
        //        db.Update(user);
        //        db.SaveChanges();
        //    }
        //}

        [HttpPost]
        public JsonResult CreateAccount(User user)
        {


            try
            {
                if (db.Users.Count() > 0)
                {
                    if (Duplicate(user.UserName, 1))
                    {
                        return Json(new { success = false, result = "Već postoji registrovan korisnik sa unetim korisničkim imenom" });
                    }
                    if (Duplicate(user.Email, 2))
                    {
                        return Json(new { success = false, result = "Već postoji registrovan korisnik sa unetom e-mail adresom" });
                    }
                }

                //todo :uros mapiranje 
                DBModel.Models.User dbUser = new DBModel.Models.User();
                dbUser.UserName = user.UserName;
                dbUser.Password = user.Password;
                dbUser.RepeatedPassword = user.RepeatedPassword;
                dbUser.FarmName = user.FarmName;
                dbUser.FarmNo = user.FarmNo;
                dbUser.Email = user.Email;
                dbUser.IndLogged = 0;
                db.Add(dbUser);
                db.SaveChanges();

                return Json(new { success = true });           
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }

        private bool Duplicate(string value, int indParameter)
        {
            bool isDuplicate = false;
            switch (indParameter)
            {
                case 1://username
                    isDuplicate = db.Users.Any(x => x.UserName.ToUpper().Trim() == value.ToUpper().Trim());
                    break;
                case 2://email
                    isDuplicate = db.Users.Any(x => x.Email.ToUpper().Trim() == value.ToUpper().Trim());
                    break;
                default:
                    break;
            }
            return isDuplicate;
        }


    }
}
