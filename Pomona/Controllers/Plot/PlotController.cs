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
    public class PlotController : Controller
    {
        private readonly IPlotService service;
        private static List<Pomona.Models.Plot> plots
        {
            get; set;
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

        public IActionResult AddingPlotRows()
        {
            return View();

        }

        [HttpGet]
        public object GetPlots(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(plots, loadOptions);
        }

        [HttpGet]
        public object GetPlotList(DataSourceLoadOptions loadOptions)
        {
            //todo : uros kad odradi plot list da zameni ovo testno sa pozivom iz baze
            List<PlotList> list = new List<PlotList>();
            PlotList pl = new PlotList();
            pl.PlotListId = 1;
            pl.PlotListName = "Lepa parcela";
            list.Add(pl);
            pl = new PlotList();
            pl.PlotListId = 2;
            pl.PlotListName = "Ruzna parcela";
            list.Add(pl);

            return DataSourceLoader.Load(list, loadOptions);
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
        [HttpPost]
        public JsonResult SavePlotRows(PlotRows plotRows)
        {
            try
            {
                int countInsertedForDisplay = 0;

                if (plotRows != null && plotRows.PlotListId > 0)
                {

                    int row = 0;

                    int.TryParse(plotRows.RowCount, out row);
                    if (row == 0)
                    {
                        #region uneta slovna vrednost 
                        if (!plots.Any(x => x.PlotLabel == plotRows.RowCount))
                        {
                            var plot = new Pomona.Models.Plot();
                            plot.PlotListId = plotRows.PlotListId;
                            plot.PlotLabel = plotRows.RowCount;
                            service.AddPlot(plot);
                            countInsertedForDisplay = 1;
                        }
                        else
                        {
                            countInsertedForDisplay = 0;
                        }
                        #endregion
                    }

                    else
                    {
                        #region uneta numericka vrednost
                        List<decimal> list = RangeIncrement(1, Convert.ToInt32(plotRows.RowCount), 1);

                        foreach (var num in list)
                        {
                            if (!plots.Any(x => x.PlotListId == plotRows.PlotListId && x.PlotLabel == num.ToString()))
                            {
                                var plot = new Pomona.Models.Plot();
                                plot.PlotListId = plotRows.PlotListId;
                                plot.PlotLabel = num.ToString();
                                service.AddPlot(plot);
                                countInsertedForDisplay++;
                            }
                        }
                        #endregion
                    }


                    service.SaveChanges();
                    RefreshSources();
                }
                return Json(new { success = true, result = countInsertedForDisplay });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }


        private List<decimal> RangeIncrement(decimal start, decimal end, decimal increment)
        {
            return Enumerable
                .Repeat(start, (int)((end - start) / increment) + 1)
                .Select((tr, ti) => tr + (increment * ti))
                .ToList();
        }


        private void RefreshSources()
        {
            plots = service.GetPlots();
        }
    }
}
