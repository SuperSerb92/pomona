using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Controllers.BarCodeGenerator
{
    public class BarCodeGeneratorController : Controller
    {
      
        private List<Models.BarCodeGenerator> barcodes
        {
            get
            {
                return (Session.AppContext.MemoryCache.Get("BarCodeList_" + Session.AppContext.Id) == null)
                    ? null : (List<Models.BarCodeGenerator>)(Session.AppContext.MemoryCache.Get("BarCodeList_" + Session.AppContext.Id));
            }
            set
            {
                Session.AppContext.MemoryCache.Set("BarCodeList_" + Session.AppContext.Id, value);
            }
        }
        public BarCodeGeneratorController()
        {
          
        }
        public IActionResult BarCodeGenerator()
        {
            //ba = db.Employees.ToList();
            return View();
        }
    }
}
