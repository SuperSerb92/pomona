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
using Pomona.Interfaces;

namespace Pomona.Controllers.Plot
{
    public class PlotController :Controller
    {
        private readonly IPlotService service;
        private static List<Pomona.Models.Plot> plots
        {
            get;set;
        }
        public PlotController(IPlotService service)
        {
            this.service = service;
        }
        public IActionResult Plot()
        {
            plots = service.GetPlots();
      
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
            plots = service.GetPlots();

            return DataSourceLoader.Load(plots, loadOptions);
        }


        [HttpPost]
        public IActionResult InsertPlot(string values)
        {
            var plot = new Pomona.Models.Plot();
            JsonConvert.PopulateObject(values, plot);
            service.AddPlot(plot);
            service.SaveChanges();
            RefreshSources();
          
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatePlot(int key, string values)
        {
            var plot = plots.FirstOrDefault(a => a.PlotId == key);
            JsonConvert.PopulateObject(values, plot);
            if (plot != null)
            {
                JsonConvert.PopulateObject(values, plot);
                service.UpdatePlot(plot);
                service.SaveChanges();
            }

            RefreshSources();

            return Ok();
        }

        [HttpDelete]
        public void DeletePlot(int key)
        {
            var plot = plots.FirstOrDefault(a => a.PlotId == key);
            if (plot != null)
            {
                service.DeletePlot(plot);
                plots.Remove(plot);
                service.SaveChanges();
            }

        }

        private void RefreshSources()
        {
            plots = service.GetPlots();
        }
    }
}
