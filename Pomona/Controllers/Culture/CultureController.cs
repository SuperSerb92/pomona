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
        ICultureTypeService typeService;
        private static List<Pomona.Models.Culture> cultures
        {
            get;set;
        }
        private static List<Pomona.Models.CultureType> cultureTypes
        {
            get; set;
        }
        public CultureController(ICultureService service, ICultureTypeService typeService)
        {
            this.service = service;
            this.typeService = typeService;
        }
        public IActionResult Culture()
        {
            cultures = service.GetCultures();
            cultureTypes = typeService.GetCultureTypes();

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
                var types = cultureTypes.Where(t => t.CultureId == culture.CultureId).ToList();

                if(types != null)
                {
                    foreach (var item in types.ToList())
                    {
                        typeService.DeleteCultureType(item);
                        types.Remove(item);
                    }                  
                }
               
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
