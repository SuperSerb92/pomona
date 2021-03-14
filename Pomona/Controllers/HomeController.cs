using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Pomona.Controllers
{
    public class HomeController : Controller
    {
        private List<string> loggedSessions
        {
            get
            {
                return (Session.AppContext.MemoryCache.Get("loggedUser_") == null)
                    ? null : (List<string>)(Session.AppContext.MemoryCache.Get("loggedUser_"));
            }
            set
            {
                Session.AppContext.MemoryCache.Set("loggedUser_", value);
            }
        }


        public IActionResult Index(byte[] autentification)
        {
            if(loggedSessions == null)
            {
                loggedSessions = new List<string>();
            }
            try
            {
                string userName = Convert.ToBase64String(autentification);

                if (loggedSessions.Contains(userName))
                {
                    return BadRequest(" Korisnik je već ulogovan!");
                }
                else
                {
                    loggedSessions.Add(userName);
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
          
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
