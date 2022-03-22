using AutoMapper;
using DataAccessLayer.EF.Repositories;
using DBModel.Interfaces;
using Pomona.Interfaces;
using Pomona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Services
{
    public class PlotService : IPlotService
    {
        private readonly IPlotRepository plotRepository;
        private readonly IMapper mapper;

        public PlotService(IPlotRepository plotRepository, IMapper mapper)
        {
            this.plotRepository = plotRepository;
            this.mapper = mapper;
        }
        public void AddPlot(Plot plot)
        {
            var plotDB = mapper.Map<DBModel.Models.Plot>(plot);
            plotRepository.Add(plotDB);
        }

        public  void DeletePlot(Plot plot)
        {
            var plotDB = mapper.Map<DBModel.Models.Plot>(plot);
            plotRepository.Delete(plotDB);
        }

        public List<Plot> GetPlots()
        {
            var plots = plotRepository.GetPlots();
            var plotsDB = mapper.Map<IEnumerable<Models.Plot>>(plots);
            return plotsDB.OrderBy(x => x.PlotListId).ThenBy(a=>a.PlotLabel).ToList();
        }

        public void SaveChanges()
        {
            plotRepository.SaveChanges();
        }

        public void UpdatePlot(Plot plot)
        {
            var plotDB = mapper.Map<DBModel.Models.Plot>(plot);
            plotRepository.Update(plotDB);
        }
    }
}
