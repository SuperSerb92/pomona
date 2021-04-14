using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Pomona.Interfaces;
using Pomona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Controllers.Packaging
{
    public class PackagingController : Controller
    {
        private readonly IPackagingService service;

        private static List<Pomona.Models.Packaging> packagings
        {
            get;set;
        }
        public PackagingController(IPackagingService service)
        {
            this.service = service;
        }
        public IActionResult Packaging()
        {
            packagings = service.GetPackagings();
        
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
            packagings = service.GetPackagings();

            return DataSourceLoader.Load(packagings, loadOptions);
        }


        [HttpPost]
        public IActionResult InsertPackaging(string values)
        {
            var packaging = new Pomona.Models.Packaging();
            JsonConvert.PopulateObject(values, packaging);
            service.AddPackaging(packaging);
            service.SaveChanges();

            RefreshResources();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatePackaging(int key, string values)
        {
            var package = packagings.FirstOrDefault(a => a.PackagingId == key);
            if (package != null)
            {
                JsonConvert.PopulateObject(values, package);
                service.UpdatePackaging(package);
                service.SaveChanges();
                RefreshResources();
            }
            return Ok();
        }

        [HttpDelete]
        public void DeletePackaging(int key)
        {
            var package = packagings.FirstOrDefault(a => a.PackagingId == key);
            if (package != null)
            {
                service.DeletePackaging(package);
                service.SaveChanges();
                packagings.Remove(package);
            }

        }

        private void RefreshResources()
        {
            packagings = service.GetPackagings();
        }
    }
}
