
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
namespace Pomona.Controllers.CultureType
{
    public class CultureTypeController : Controller
    {
        private readonly ICultureTypeService service;
        private readonly ICultureService cultureService;
        private static List<Pomona.Models.CultureType> CultureTypes
        {
            get; set;
        }
        private static List<Pomona.Models.Culture> Cultures
        {
            get; set;
        }
        public CultureTypeController(ICultureTypeService service, ICultureService cultureService)
        {
            this.service = service;
            this.cultureService = cultureService;
        }
        public IActionResult CultureType()
        {
            CultureTypes = service.GetCultureTypes();
            Cultures = cultureService.GetCultures();

            //List<Models.CultureType> dbCultureTypes = null;//db.CultureTypes.ToList();
            //Pomona.Models.CultureType ct = new Models.CultureType();
            //Pomona.Models.Culture culture = new Models.Culture();
            //CultureTypes = new List<Models.CultureType>();
            ////todo uros mapiranje
            //foreach (var item in dbCultureTypes)
            //{
            //    ct = new Models.CultureType();
            //    // ct.Culture = item.Culture;
            //    ct.CultureTypeId = item.CultureTypeId;
            //    ct.CultureId = item.CultureId;
            //    ct.CultureTypeName = item.CultureTypeName;                  
            //    if (item.Culture != null)
            //    {
            //        culture = new Models.Culture();
            //        culture.CultureId = item.Culture.CultureId;
            //        culture.CultureName = item.Culture.CultureName;
            //        ct.Culture = culture;
            //    }
            //    CultureTypes.Add(ct);
            //}

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
            CultureTypes = service.GetCultureTypes();

            return DataSourceLoader.Load(CultureTypes, loadOptions);
        }


        [HttpPost]
        public IActionResult InsertCultureType(string values)
        {
            var culture = new Pomona.Models.CultureType();
            JsonConvert.PopulateObject(values, culture);
            service.AddCultureType(culture);
            service.SaveChanges();
            RefreshResources();

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCultureType(int key, string values)
        {
            var culture = CultureTypes.FirstOrDefault(a => a.CultureTypeId == key);
            JsonConvert.PopulateObject(values, culture);
            if (culture != null)
            {
                JsonConvert.PopulateObject(values, culture);
                service.UpdateCultureType(culture);
                service.SaveChanges();
                RefreshResources();
            }
            return Ok();
        }

        [HttpDelete]
        public void DeleteCultureType(int key)
        {
            var culture = CultureTypes.FirstOrDefault(a => a.CultureTypeId == key);
            if (culture != null)
            {
                service.DeleteCultureType(culture);
                service.SaveChanges();
                CultureTypes.Remove(culture);
            }

        }

        private void RefreshResources()
        {
            CultureTypes = service.GetCultureTypes();
            Cultures = cultureService.GetCultures();
        }
    }
}
