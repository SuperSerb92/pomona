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

namespace Pomona.Controllers.Buyer
{
    public class BuyerController : Controller
    {
        private readonly IBuyerService service;
        private static List<Models.Buyer> buyers
        {
            get; set;
        }
        public BuyerController(IBuyerService service)
        {
            this.service = service;
        }
        public IActionResult Buyer()
        {
            buyers = service.GetBuyers();

            return View();
        }

        [HttpGet]
        public object GetBuyers(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(buyers, loadOptions);
        }

        [HttpGet]
        public object GetBuyersStaticList(DataSourceLoadOptions loadOptions)
        {
            buyers = service.GetBuyers();

            return DataSourceLoader.Load(buyers, loadOptions);
        }


        [HttpPost]
        public IActionResult InsertBuyer(string values)
        {
            var buyer = new Models.Buyer();
            JsonConvert.PopulateObject(values, buyer);
            if (buyers.Any(x => x.Pib.Trim().ToUpper() == buyer.Pib.Trim().ToUpper()))
            {
                return BadRequest("Otkupljivač sa unetim pib-om već postoji u sistemu");
            }

            service.AddBuyer(buyer);
            service.SaveChanges();
            RefreshResources();

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBuyer(int key, string values)
        {
            var buyer = buyers.FirstOrDefault(a => a.BuyerId == key);
            if (buyer != null)
            {
                JsonConvert.PopulateObject(values, buyer);
                service.UpdateBuyer(buyer);
                service.SaveChanges();
            }
            RefreshResources();
            return Ok();
        }

        [HttpDelete]
        public void DeleteBuyer(int key)
        {
            //todo: kad je spusten kljuc ne sme se brisati?
            var buyer = buyers.FirstOrDefault(a => a.BuyerId == key);
            if (buyer != null)
            {
                service.DeleteBuyer(buyer);
                service.SaveChanges();
                buyers.Remove(buyer);
            }
        }

        private void RefreshResources()
        {
            buyers = service.GetBuyers();
        }

        public JsonResult CheckForDuplicatePib(string Pib)
        {
            //todo: uzimamo svezu listu zbog paralelnog rada za svaki slucaj
            var buyersList = service.GetBuyers();
            if(buyersList != null)
            {
                if (buyersList.Any(x => x.Pib.Trim().ToUpper() == Pib.Trim().ToUpper()))
                {
                    return Json(new { success = false });
                }
            }

            return Json(new { success = true });

        }
    }
}
