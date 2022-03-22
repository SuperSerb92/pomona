using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pomona.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Controllers.Repurchase
{
    public class RepurchaseController:Controller
    {
        private readonly IRepurchaseService service;
        private readonly IBarCodeGeneratorService barCodeGeneratorService;
        private static List<Models.Repurchase> repurchases
        {
            get; set;
        }
        private static List<Pomona.Models.BarCodeGenerator> barcodes
        {
            get; set;
        }
        public RepurchaseController(IRepurchaseService service, IBarCodeGeneratorService barCodeGeneratorService)
        {
            this.barCodeGeneratorService = barCodeGeneratorService;
            this.service = service;
        }
        public IActionResult Repurchase()
        {
            repurchases = service.GetRepurchases();

            return View();
        }

        [HttpGet]
        public object GetRepurchases(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(repurchases, loadOptions);
        }

        [HttpGet]
        public object GetRepurchasesStaticList(DataSourceLoadOptions loadOptions)
        {
            repurchases = service.GetRepurchases();

            return DataSourceLoader.Load(repurchases, loadOptions);
        }

        [HttpPost]
        public IActionResult InsertRepurchase(string values)
        {
            var rep = new Models.Repurchase();
            JsonConvert.PopulateObject(values, rep);
            if (rep.Price==0 || rep.NetoShipped==0)
            {
                rep.Income = 0;
            }
            else
            {
                rep.Income = rep.Price * rep.NetoShipped;
            }
            rep.Difference = rep.NetoShipped - rep.Neto;
            rep.Date = rep.Date.Date;

            service.AddRepurchase(rep);
            service.SaveChanges();
            RefreshSources();

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateRepurchase(int key, string values)
        {
            var rep = repurchases.FirstOrDefault(a => a.Id == key);
            if (rep != null)
            {
                JsonConvert.PopulateObject(values, rep);
                if (rep.Price == 0 || rep.NetoShipped == 0)
                {
                    rep.Income = 0;
                }
                else
                {
                    rep.Income = rep.Price * rep.NetoShipped;
                }
                rep.Difference = rep.NetoShipped - rep.Neto;

                service.UpdateRepurchase(rep);
                service.SaveChanges();
            }

            RefreshSources();

            return Ok();
        }

        [HttpDelete]
        public void DeleteRepurchase(int key)
        {
            var rep = repurchases.FirstOrDefault(a => a.Id == key);
            if (rep != null)
            {
                service.DeleteRepurchase(rep);
                repurchases.Remove(rep);
                service.SaveChanges();
            }
        }



        private void RefreshSources()
        {
            repurchases = service.GetRepurchases();
        }

        [HttpGet]
        public object GetNeto(int key,DateTime date)
        {
            decimal neto = 0;
            decimal netoRep = 0;
            var rep = repurchases.Where(x => x.CultureId == key && x.Date.Date == date.Date).ToList();
          
            barcodes = barCodeGeneratorService.GetBarCodeActive().Where(x=> x.CultureId==key && x.DateGenerated.Date==date.Date).ToList();
            if (barcodes.Count >0)
            {
                 neto = barcodes.Sum(x=>x.Neto);
                if (rep.Count() > 0)
                {
                    netoRep = rep.Sum(a => a.Neto);
                }
                neto = neto - netoRep;
            }
            else
            {
                return Json(new { success = false, result = "Ne postoji težina za odabrani datum i vrstu voća" });
            }

            return Json(new { success = true, result = neto });
            // return Ok();

        }
    }
}
