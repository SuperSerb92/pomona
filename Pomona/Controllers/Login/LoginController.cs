using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pomona.Models;

namespace Osa.Unidocs.Web.MetaDesigner.Controllers.Login
{
    public class LoginController : Controller//, Osa.Unidocs.Modules.Login.View.ILoginView
    {
     
        public string username;
        public string password;

        public LoginController()
        {
          
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(User user)
        {
            try
            {
                //string id = Osa.Unidocs.Shared.Common.AppContext.Id;
                //this.Username = user.Login;
                //this.Password = user.Passwd;
                //controller.Login();
        

                return Json(new { success = true, message = "Uspesno logovanje:" });//ne ispaljuje se ne mora da se lokalizuje
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult CreateAccount(User user)
        {
            try
            {

                return Json(new { success = true, message = "Uspesno logovanje:" });//ne ispaljuje se ne mora da se lokalizuje
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        //#region private methods
        //private void OnViewLoad()
        //{
        //    controller.BindControlLogin();
        //}

        //#endregion

    }
}
