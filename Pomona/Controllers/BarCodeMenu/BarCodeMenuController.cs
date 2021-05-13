using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Pomona.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Controllers.BarCodeMenu
{
    public class BarCodeMenuController : Controller
    {
        private readonly IBarCodeGeneratorService service;
        //private List<Models.BarCodeGenerator> barcodes
        //{
        //    get
        //    {
        //        return (Session.AppContext.MemoryCache.Get("BarCodeList_" + Session.AppContext.Id) == null)
        //            ? null : (List<Models.BarCodeGenerator>)(Session.AppContext.MemoryCache.Get("BarCodeList_" + Session.AppContext.Id));
        //    }
        //    set
        //    {
        //        Session.AppContext.MemoryCache.Set("BarCodeList_" + Session.AppContext.Id, value);
        //    }
        //}
        private static List<Pomona.Models.BarCodeGenerator> barcodes
        {
            get; set;
        }
        public BarCodeMenuController(IBarCodeGeneratorService service)
        {
            this.service = service;
        }
        public IActionResult BarCodeGenerator()
        {
            //ba = db.Employees.ToList();
            return View();
        }
        public IActionResult BarCodeMenu()
        {
            barcodes = service.GetBarCode();
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
                barCode.Rbr++;//rbr dobija svaki radnik zasebno na taj dan
                JsonConvert.PopulateObject(values, barCode);
                service.AddBarCode(barCode);
                service.SaveChanges();
                RefreshSources();

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBarcode(int key, string values)
        {
          

            return Ok();
        }

        [HttpDelete]
        public void DeleteBarcode(int key)
        {
           
        }

        private void RefreshSources()
        {
            barcodes = service.GetBarCode();
        }
    }
}
