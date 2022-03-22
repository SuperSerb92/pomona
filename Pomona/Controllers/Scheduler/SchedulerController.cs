using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pomona.Models;

namespace Pomona.Controllers.Scheduler
{
    public class SchedulerController : Controller
    {
        public ActionResult Scheduler()
        {
            return View(SchedulerItems.Appointments);
        }
    }
}
