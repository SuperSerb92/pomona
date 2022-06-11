using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Pomona.Interfaces;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Pomona.Controllers.BarCodeReader
{
    public class BarCodeReaderController:Controller
    {
        private readonly IBarCodeGeneratorService service;
        private readonly IConfiguration _config;
        private readonly IWorkEvaluationService workService;
        string port; 
        private static List<Pomona.Models.BarCodeGenerator> barcodes
        {
            get; set;
        }
        public BarCodeReaderController(IBarCodeGeneratorService service, IConfiguration config, IWorkEvaluationService workService)
        {
            this.service = service;
            this.workService = workService;
            _config = config;
            port = _config.GetValue<string>("Logging:Port");

        }
  
        public IActionResult BarCodeReader()
        {
            barcodes = service.GetBarCodeActive().Where(x => x.DateGenerated >= DateTime.Now.AddDays(-4)).OrderByDescending(a => a.MaxRbr).ToList();
            //ba = db.Employees.ToList();
            return View();
        }
        [HttpGet]
        public object GetBarCodes(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(barcodes, loadOptions);
        }


        [HttpPost]
        public IActionResult InsertBarcode(string values)
        {
            var barCode = new Models.BarCodeGenerator();

            JsonConvert.PopulateObject(values, barCode);

            var barc = barcodes.FirstOrDefault(a => a.BarCode == barCode.BarCode);
            if (barc != null)
            {
                if (barc.Bruto > barc.Tara)
                {
                    JsonConvert.PopulateObject(values, barc);
                    barc.Neto = barc.Bruto - barc.Tara;
                    service.UpdateBarCode(barc);
                    service.SaveChanges();
                }
            }

            RefreshSources();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBarcode(string key, string values)
        {
            
                var barc = barcodes.FirstOrDefault(a => a.BarCode == key);
            if (barc != null)
            {
                JsonConvert.PopulateObject(values, barc);
                if (barc.Bruto > barc.Tara && barc.IndikatorStorn==false)
                {
                   
                    barc.Neto = barc.Bruto - barc.Tara;
                    barc.LoggedUserID = Session.AppContext.UserID;
                    service.UpdateBarCode(barc);
                    service.SaveChanges();
                }
                if (barc.IndikatorStorn==true)
                {
                    barc.Status = 1;
                    barc.StatusDisplay = "Neaktivan";
                    service.UpdateBarCode(barc);
                    service.SaveChanges();
                }
      
            }

            RefreshSources();

            return Ok();
        }

        [HttpDelete]
        public void DeleteBarcode(string key)
        {
            var barc = barcodes.FirstOrDefault(a => a.BarCode == key);
            if (barc != null)
            {
                barc.Status = 1;
                service.UpdateBarCode(barc);
                service.SaveChanges();
            }

            RefreshSources();
        }
        private void RefreshSources()
        {
            barcodes = service.GetBarCodeActive().Where(x => x.DateGenerated >= DateTime.Now.AddDays(-4)).OrderByDescending(a => a.MaxRbr).ToList();
        }
        decimal vrednostSaVage = 0;
        [HttpGet]
        public object Measure(string key)
        {

            service.Measure(ref vrednostSaVage,port);
           // vrednostSaVage =Convert.ToDecimal(2.56);
            var barc = barcodes.FirstOrDefault(a => a.BarCode == key);
            if (barc != null)
            {
                barc.Bruto = vrednostSaVage;
                if (barc.Bruto > barc.Tara)
                {
                   
                    barc.Neto = barc.Bruto - barc.Tara;
                    barc.LoggedUserID = Session.AppContext.UserID;
                    service.UpdateBarCode(barc);
                    service.SaveChanges();
                }
                else
                {
                    return Json(new { success = true, result="Tezina je manja od tare." });
                }
            }

            RefreshSources();
              return Json(new { success = true, result = barcodes });
           
            
        }

      

    }
}
