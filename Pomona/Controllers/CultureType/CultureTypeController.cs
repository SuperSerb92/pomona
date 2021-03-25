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
namespace Pomona.Controllers.CultureType
{
    public class CultureTypeController : Controller
    {
        readonly DbModelContext db;
        private List<Pomona.Models.CultureType> CultureTypes
        {
            get
            {
                return (Session.AppContext.MemoryCache.Get("CultureTypeList_" + Session.AppContext.Id) == null)
                    ? null : (List<Pomona.Models.CultureType>)(Session.AppContext.MemoryCache.Get("CultureTypeList_" + Session.AppContext.Id));
            }
            set
            {
                Session.AppContext.MemoryCache.Set("CultureTypeList_" + Session.AppContext.Id, value);
            }
        }
        public CultureTypeController(DBModel.DataAccess.DbModelContext db)
        {
            this.db = db;
        }
        public IActionResult CultureType()
        {
            List<DBModel.Models.CultureType> dbCultureTypes = db.CultureTypes.ToList();
            Pomona.Models.CultureType ct = new Models.CultureType();
            Pomona.Models.Culture culture = new Models.Culture();
            CultureTypes = new List<Models.CultureType>();
            //todo uros mapiranje
            foreach (var item in dbCultureTypes)
            {
                ct = new Models.CultureType();
                // ct.Culture = item.Culture;
                ct.CultureTypeId = item.CultureTypeId;
                ct.CultureId = item.CultureId;
                ct.CultureTypeName = item.CultureTypeName;                  
                if (item.Culture != null)
                {
                    culture = new Models.Culture();
                    culture.CultureId = item.Culture.CultureId;
                    culture.CultureName = item.Culture.CultureName;
                    ct.Culture = culture;
                }
                CultureTypes.Add(ct);
            }

            return View();
        }

        [HttpGet]
        public object GetCultureTypes(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(CultureTypes, loadOptions);
        }

        [HttpGet]
        public object GetCultureTypesStaticList(DataSourceLoadOptions loadOptions)
        {
            List<DBModel.Models.CultureType> dbCultureTypes = db.CultureTypes.ToList();

            return DataSourceLoader.Load(CultureTypes, loadOptions);
        }


        [HttpPost]
        public IActionResult InsertCultureType(string values)
        {
            var culture = new Pomona.Models.CultureType();
          
            JsonConvert.PopulateObject(values, culture);

            //todo: pitaj coku jel hocemo insert u prvi red  ili poslednji ovo ispod je insert na prvo mesto
            //cultures.Insert(0, culture);

            CultureTypes.Add(culture);
            db.Add(culture);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCultureType(int key, string values)
        {
            var culture = CultureTypes.FirstOrDefault(a => a.CultureTypeId == key);
            JsonConvert.PopulateObject(values, culture);

            db.Update(culture);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public void DeleteCultureType(int key)
        {
            //todo: kad je spusten kljuc ne sme se brisati?

            var culture = CultureTypes.FirstOrDefault(a => a.CultureTypeId == key);
            db.Remove(culture);
            db.SaveChanges();
            CultureTypes.Remove(culture);

        }
    }
}
