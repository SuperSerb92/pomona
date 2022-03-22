using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Pomona.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Controllers.SummaryReport
{
    public class SummaryReportController:Controller
    {
        private readonly ISummaryReportService service;
        private static List<Pomona.Models.SummaryReport> summaries
        {
            get; set;
        }
        public SummaryReportController(ISummaryReportService service)
        {
            this.service = service;
        }
        public IActionResult SummaryReport()
        {
            //ba = db.Employees.ToList();
            summaries = new List<Models.SummaryReport>();
            return View();
        }
        [HttpGet]
        public object GetReport(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(summaries, loadOptions);
        }
        [HttpGet]
        public object GetSummary(string DatumOd,string DatumDo)
        {          
            summaries = service.GetSummaryReport(DatumOd,DatumDo);

            if (summaries!=null)
            {
                foreach (var item in summaries)
                {
                    var check = summaries.Where(x => x.DistinctNoWorkers == 1 && x.EmployeeId == item.EmployeeId).ToList();
                    if (check.Count()==0)
                    {
                        item.DistinctNoWorkers = 1;
                    }
                    else
                    {
                        item.DistinctNoWorkers = 0;
                    }
                }
            }
            
            return Json(new { success = true, result =summaries });
            // return DataSourceLoader.Load(summaries, loadOptions);
        }
    }
}
