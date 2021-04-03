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

namespace Pomona.Controllers.Culture
{
    public class CultureController : Controller
    {
        ICultureService service;
        private static List<Pomona.Models.Culture> cultures
        {
            get;set;
        }
        public CultureController(ICultureService service)
        {
            this.service = service;
        }
        public IActionResult Culture()
        {
            cultures = service.GetCultures();
          
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
            cultures = service.GetCultures();
            return DataSourceLoader.Load(cultures, loadOptions);
        }


        [HttpPost]
        public IActionResult InsertCulture(string values)
        {
            var culture = new Pomona.Models.Culture();
            JsonConvert.PopulateObject(values, culture);
            service.AddCulture(culture);
            service.SaveChanges();

            RefreshResources();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCulture(int key, string values)
        {
            var culture = cultures.FirstOrDefault(a => a.CultureId == key);
            if (culture != null)
            {
                JsonConvert.PopulateObject(values, culture);
                service.UpdateCulture(culture);
                service.SaveChanges();
                RefreshResources();
            }
            return Ok();
        }

        [HttpDelete]
        public void DeleteCulture(int key)
        {         
            var culture = cultures.FirstOrDefault(a => a.CultureId == key);
            if (culture != null)
            {
                service.DeleteCulture(culture);
                service.SaveChanges();
                cultures.Remove(culture);
            }
        }
        private void RefreshResources()
        {
            cultures = service.GetCultures();
        }
    }
}
