using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Controllers.TreeViewPomona
{
    public class TreeViewPomonaController : Controller
    {
        public IActionResult TreeViewPomona()
        {
            return View();
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(Pomona.Models.TreeItemsPomona.TreeItems, loadOptions);
        }
    }
}
