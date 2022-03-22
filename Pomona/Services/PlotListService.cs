using AutoMapper;
using DBModel.Interfaces;
using Pomona.Interfaces;
using Pomona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Services
{
    public class PlotListService : IPlotListService
    {
        private readonly IPlotListRepository plotListRepository;
        private readonly IMapper mapper;

        public PlotListService(IPlotListRepository plotRepository, IMapper mapper)
        {
            this.plotListRepository = plotRepository;
            this.mapper = mapper;
        }
        public void AddPlot(PlotList plotL)
        {
            var plotDB = mapper.Map<DBModel.Models.PlotList>(plotL);
            plotListRepository.Add(plotDB);
        }

        public void DeletePlot(PlotList plotL)
        {
            var plotDB = mapper.Map<DBModel.Models.PlotList>(plotL);
            plotListRepository.Delete(plotDB);
        }

        public List<PlotList> GetPlotLists()
        {
            var plots = plotListRepository.GetPlotLists();
            var plotsDB = mapper.Map<IEnumerable<Models.PlotList>>(plots);
            return plotsDB.ToList();
        }

        public void SaveChanges()
        {
            plotListRepository.SaveChanges();
        }

        public void UpdatePlot(PlotList plotL)
        {
            var plotDB = mapper.Map<DBModel.Models.PlotList>(plotL);
            plotListRepository.Update(plotDB);
        }
    }
}
