using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Pomona.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string guid)
        {
           // bool isValid = Guid.TryParse(guid, out output);

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
