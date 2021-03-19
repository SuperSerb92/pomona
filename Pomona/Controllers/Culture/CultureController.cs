using DBModel.DataAccess;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Pomona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Controllers.Culture
{
    public class CultureController : Controller
    {
        readonly DbModelContext db;
        private List<DBModel.Models.Culture> cultures
        {
            get
            {
                return (Session.AppContext.MemoryCache.Get("CultureList_" + Session.AppContext.Id) == null)
                    ? null : (List<DBModel.Models.Culture>)(Session.AppContext.MemoryCache.Get("CultureList_" + Session.AppContext.Id));
            }
            set
            {
                Session.AppContext.MemoryCache.Set("CultureList_" + Session.AppContext.Id, value);
            }
        }
        public CultureController(DBModel.DataAccess.DbModelContext db)
        {
            this.db = db;
        }
        public IActionResult Culture()
        {
            cultures = db.Cultures.ToList();
            return View();
        }

        [HttpGet]
        public object GetCultures(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(cultures, loadOptions);
        }

        [HttpGet]
        public object GetCulturesStaticList(DataSourceLoadOptions loadOptions)
        {
            cultures = db.Cultures.ToList();

            return DataSourceLoader.Load(cultures, loadOptions);
        }


        [HttpPost]
        public IActionResult InsertCulture(string values)
        {
            var culture = new DBModel.Models.Culture();
            JsonConvert.PopulateObject(values, culture);

            //todo: pitaj coku jel hocemo insert u prvi red  ili poslednji ovo ispod je insert na prvo mesto
            //cultures.Insert(0, culture);

            cultures.Add(culture);
            db.Add(culture);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCulture(int key, string values)
        {
            var culture = cultures.FirstOrDefault(a => a.CultureId == key);
            JsonConvert.PopulateObject(values, culture);

            db.Update(culture);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public void DeleteCulture(int key)
        {
            //todo: kad je spusten kljuc ne sme se brisati?

            var culture = cultures.FirstOrDefault(a => a.CultureId == key);
            db.Remove(culture);
            db.SaveChanges();
            cultures.Remove(culture);

        }
    }
}
