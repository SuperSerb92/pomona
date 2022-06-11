using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Pomona.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pomona.Controllers.BarcodeStorn
{
    public class BarcodeStornController : Controller
    {
        private readonly IBarCodeGeneratorService service;
        private readonly IConfiguration _config;

        private static List<Pomona.Models.BarCodeGenerator> barcodes
        {
            get; set;
        }
        public BarcodeStornController(IBarCodeGeneratorService service, IConfiguration config)
        {
            this.service = service;          
            _config = config;
            
        }
        public IActionResult BarcodeStorn()
        {
            barcodes = service.GetBarCodeActive().Where(x => x.Bruto == 0 && x.Status==0).OrderByDescending(a => a.MaxRbr).ToList();
          
            return View();
        }
        [HttpGet]
        public object GetBarCodesStorn(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(barcodes, loadOptions);
        }

        public IActionResult UpdateBarcodeStorn(string key, string values)
        {

            var barc = barcodes.FirstOrDefault(a => a.BarCode == key);
            if (barc != null)
            {
                JsonConvert.PopulateObject(values, barc);
           
                if (barc.IndikatorStorn == true)
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
        private void RefreshSources()
        {
            barcodes = service.GetBarCodeActive().Where(x => x.Bruto == 0 && x.Status == 0).OrderByDescending(a => a.MaxRbr).ToList();
        }
    }
}
