using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pomona.Interfaces;

namespace Pomona.Controllers.ProfitLossReport
{
    public class ProfitLossReportController : Controller
    {
        private readonly IProfitLossReportService service;
       
        private static List<Models.ProfitLossReport> profitLossReports
        {
            get; set;
        }
        private static List<Models.ProfitLossSum> profitLossSums
        {
            get; set;
        }
        public ProfitLossReportController(IProfitLossReportService service)
        {
            this.service = service;
        }
        public IActionResult ProfitLossReport()
        {
            profitLossReports = new List<Models.ProfitLossReport>();
            profitLossSums = new List<Models.ProfitLossSum>();
            return View();
        }
        [HttpGet]
        public object GetReport(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(profitLossReports, loadOptions);
        }
        [HttpGet]
        public object GetReportSum(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(profitLossReports, loadOptions);
        }
        [HttpGet]
        public object GetProfitLoss(string DatumOd, string DatumDo)
        {
            profitLossReports = service.GetProfitLossReport(DatumOd, DatumDo);


            return Json(new { success = true, result = profitLossReports });
           
        }

        [HttpGet]
        public object GetProfitLossSum(string DatumOd, string DatumDo)
        {
            profitLossReports = service.GetProfitLossReport(DatumOd, DatumDo);
            profitLossSums.Clear();
            Models.ProfitLossSum trosak = new Models.ProfitLossSum();
            trosak.Naziv = "Trošak";
            //  trosak.Procenat =Convert.ToDecimal(profitLossReports.Sum(x => x.Trosak))/ Convert.ToDecimal((profitLossReports.Sum(x => x.Trosak)+ profitLossReports.Sum(x => x.Prihod)));
            trosak.Procenat = profitLossReports.Sum(x => x.Trosak);
            trosak.Proc = profitLossReports.Sum(x => x.Trosak).ToString("n0");
            profitLossSums.Add(trosak);

            Models.ProfitLossSum prihod = new Models.ProfitLossSum();
            prihod.Naziv = "Profit";
            //   prihod.Procenat = Convert.ToDecimal(profitLossReports.Sum(x => x.Prihod)) / Convert.ToDecimal((profitLossReports.Sum(x => x.Trosak) + profitLossReports.Sum(x => x.Prihod)));
            prihod.Procenat = profitLossReports.Sum(x => x.Profit);
            prihod.Proc = profitLossReports.Sum(x => x.Profit).ToString("n0");
            profitLossSums.Add(prihod);
            return Json(new { success = true, result = profitLossSums });

        }

        [HttpGet]
        public object GetAvgPrice(string DatumOd, string DatumDo)
        {
            decimal avgCena = service.GetAvgPrice(DatumOd, DatumDo);


            return Json(new { success = true, result = avgCena });

        }
    }
}
