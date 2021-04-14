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
        private Dictionary<string, int> loggedSessions
        {
            get
            {
                return (Session.AppContext.MemoryCache.Get("loggedSessions_") == null)
                    ? null : (Dictionary<string, int>)(Session.AppContext.MemoryCache.Get("loggedSessions_"));
            }
            set
            {
                Session.AppContext.MemoryCache.Set("loggedSessions_", value);
            }
        }

        public HomeController()
        {

        }

        public IActionResult EmptyView()
        {
            return View();
        }

        public IActionResult Index(string autentification, int token)
        {
            if (loggedSessions == null)
            {
                loggedSessions = new Dictionary<string, int>();
            }
            try
            {
                //ako uradi refresh ili copy paste
                if (loggedSessions.Keys.Contains(autentification))
                {
                    HttpContext.Response.Redirect($"/Pomona/Login/Login");
                }
                //ako je ne daj boze menjao url
                else if (!IsGuid(autentification))
                {
                    HttpContext.Response.Redirect($"/Pomona/Login/Login");
                }
                else
                {
                    Session.AppContext.UserID = token;
                    loggedSessions.Add(autentification, token);
                }

                return View();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool IsGuid(string value)
        {
            Guid x;
            return Guid.TryParse(value, out x);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
