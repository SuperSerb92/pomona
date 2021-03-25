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

namespace Pomona.Controllers.Packaging
{
    public class PackagingController : Controller
    {
        readonly DbModelContext db;
        private List<DBModel.Models.Packaging> packagings
        {
            get
            {
                return (Session.AppContext.MemoryCache.Get("PackagingList_" + Session.AppContext.Id) == null)
                    ? null : (List<DBModel.Models.Packaging>)(Session.AppContext.MemoryCache.Get("PackagingList_" + Session.AppContext.Id));
            }
            set
            {
                Session.AppContext.MemoryCache.Set("PackagingList_" + Session.AppContext.Id, value);
            }
        }
        public PackagingController(DBModel.DataAccess.DbModelContext db)
        {
            this.db = db;
        }
        public IActionResult Packaging()
        {
            packagings = db.Packagings.ToList();
            return View();
        }

        [HttpGet]
        public object GetPackagings(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(packagings, loadOptions);
        }

        [HttpGet]
        public object GetPackagingsStaticList(DataSourceLoadOptions loadOptions)
        {
            packagings = db.Packagings.ToList();

            return DataSourceLoader.Load(packagings, loadOptions);
        }


        [HttpPost]
        public IActionResult InsertPackaging(string values)
        {
            var packaging = new DBModel.Models.Packaging();
            JsonConvert.PopulateObject(values, packaging);

            //todo: pitaj coku jel hocemo insert u prvi red  ili poslednji ovo ispod je insert na prvo mesto
            //packagings.Insert(0, packaging);

            packagings.Add(packaging);
            db.Add(packaging);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatePackaging(int key, string values)
        {
            var packaging = packagings.FirstOrDefault(a => a.PackagingId == key);
            JsonConvert.PopulateObject(values, packaging);

            db.Update(packaging);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public void DeletePackaging(int key)
        {
            //todo: kad je spusten kljuc ne sme se brisati?

            var packaging = packagings.FirstOrDefault(a => a.PackagingId == key);
            db.Remove(packaging);
            db.SaveChanges();
            packagings.Remove(packaging);

        }
    }
}
