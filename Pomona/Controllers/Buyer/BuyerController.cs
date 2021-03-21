using DBModel.DataAccess;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Controllers.Buyer
{
    public class BuyerController : Controller
    {
        readonly DbModelContext db;
        private List<DBModel.Models.Buyer> buyers
        {
            get
            {
                return (Session.AppContext.MemoryCache.Get("BuyerList_" + Session.AppContext.Id) == null)
                    ? null : (List<DBModel.Models.Buyer>)(Session.AppContext.MemoryCache.Get("BuyerList_" + Session.AppContext.Id));
            }
            set
            {
                Session.AppContext.MemoryCache.Set("BuyerList_" + Session.AppContext.Id, value);
            }
        }
        public BuyerController(DBModel.DataAccess.DbModelContext db)
        {
            this.db = db;
        }
        public IActionResult Buyer()
        {
            buyers = db.Buyers.ToList();
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
            buyers = db.Buyers.ToList();

            return DataSourceLoader.Load(buyers, loadOptions);
        }


        [HttpPost]
        public IActionResult InsertBuyer(string values)
        {
            var buyer = new DBModel.Models.Buyer();
            JsonConvert.PopulateObject(values, buyer);


            buyers.Add(buyer);
            db.Add(buyer);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBuyer(int key, string values)
        {
            var buyer = buyers.FirstOrDefault(a => a.BuyerId == key);
            JsonConvert.PopulateObject(values, buyer);

            db.Update(buyer);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public void DeleteBuyer(int key)
        {
            //todo: kad je spusten kljuc ne sme se brisati?

            var buyer = buyers.FirstOrDefault(a => a.BuyerId == key);
            db.Remove(buyer);
            db.SaveChanges();
            buyers.Remove(buyer);

        }

    }
}
