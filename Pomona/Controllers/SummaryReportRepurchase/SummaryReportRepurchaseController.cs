using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pomona.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pomona.Controllers.SummaryReportRepurchase
{
    public class SummaryReportRepurchaseController : Controller
    {
        private readonly ISummaryRepurchaseService service;
        private static List<Pomona.Models.SummaryReportRepurchase> summaries
        {
            get; set;
        }
        public SummaryReportRepurchaseController(ISummaryRepurchaseService service)
        {
            this.service = service;
        }
        public IActionResult SummaryReportRepurchase()
        {
            summaries = new List<Models.SummaryReportRepurchase>();
            return View();
        }
        [HttpGet]
        public object GetReportRepurchase(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(summaries, loadOptions);
        }
        [HttpGet]
        public IActionResult GetSummaryRepurchase(string DatumOd, string DatumDo,DataSourceLoadOptions loadOptions)
        {
            summaries = service.GetSummaryReportRepurchase(DatumOd, DatumDo);

            if (summaries != null)
            {
                foreach (var item in summaries)
                {
                    if (item.Paid==true)
                    {
                        item.PaidS = "Plaćeno";
                    }
                    else
                    {
                        item.PaidS = "Nije plaćeno";
                    }
                }
            }
            var result = DataSourceLoader.Load(summaries, loadOptions);
          //  var resultJson = JsonConvert.SerializeObject(result);
          //  return Content(resultJson, "application/json");
            return Json(new { success = true, result = summaries });
           // return View();
        }
        [HttpPut]
        public IActionResult UpdateReportRepurchase(int key, string values,DateTime datumPlacanja,bool placeno)
        {
            var eval = summaries.FirstOrDefault(a => a.Id == key);
            if (eval != null)
            {
               // JsonConvert.PopulateObject(values, eval);
                eval.Comment = values;
                eval.PaidDate = datumPlacanja;
                eval.Paid = placeno;
                if (eval.Paid == true)
                {
                    eval.PaidS = "Plaćeno";
                }
                else
                {
                    eval.PaidS = "Nije plaćeno";
                }
                service.UpdateRepurchase(eval);
                service.SaveChanges();
            }

           // RefreshSources();

            return Ok();
        }
    }
}
