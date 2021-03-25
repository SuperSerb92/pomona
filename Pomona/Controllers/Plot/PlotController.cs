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


namespace Pomona.Controllers.Plot
{
    public class PlotController :Controller
    {
        readonly DbModelContext db;
        private List<DBModel.Models.Plot> plots
        {
            get
            {
                return (Session.AppContext.MemoryCache.Get("PlotList_" + Session.AppContext.Id) == null)
                    ? null : (List<DBModel.Models.Plot>)(Session.AppContext.MemoryCache.Get("PlotList_" + Session.AppContext.Id));
            }
            set
            {
                Session.AppContext.MemoryCache.Set("PlotList_" + Session.AppContext.Id, value);
            }
        }
        public PlotController(DBModel.DataAccess.DbModelContext db)
        {
            this.db = db;
        }
        public IActionResult Plot()
        {
            plots = db.Plots.ToList();
            return View();
        }

        [HttpGet]
        public object GetPlots(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(plots, loadOptions);
        }

        [HttpGet]
        public object GetPlotsStaticList(DataSourceLoadOptions loadOptions)
        {
            plots = db.Plots.ToList();

            return DataSourceLoader.Load(plots, loadOptions);
        }


        [HttpPost]
        public IActionResult InsertPlot(string values)
        {
            var plot = new DBModel.Models.Plot();
            JsonConvert.PopulateObject(values, plot);

            //todo: pitaj coku jel hocemo insert u prvi red  ili poslednji ovo ispod je insert na prvo mesto
            //plots.Insert(0, plot);

            plots.Add(plot);
            db.Add(plot);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatePlot(int key, string values)
        {
            var plot = plots.FirstOrDefault(a => a.PlotId == key);
            JsonConvert.PopulateObject(values, plot);

            db.Update(plot);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public void DeletePlot(int key)
        {
            //todo: kad je spusten kljuc ne sme se brisati?

            var plot = plots.FirstOrDefault(a => a.PlotId == key);
            db.Remove(plot);
            db.SaveChanges();
            plots.Remove(plot);

        }
    }
}
