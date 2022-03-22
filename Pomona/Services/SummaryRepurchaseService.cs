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
    public class SummaryRepurchaseService : ISummaryRepurchaseService
    {
        private readonly ISummaryRepurchaseRepository summaryRepurchaseRepository;
        private readonly IMapper mapper;
        public SummaryRepurchaseService(ISummaryRepurchaseRepository summaryRepurchaseRepository, IMapper mapper)
        {
            this.summaryRepurchaseRepository = summaryRepurchaseRepository;
            this.mapper = mapper;
        }

        public List<SummaryReportRepurchase> GetSummaryReportRepurchase(String datumOd,String datumDo)
        {
            //var summaryReport = summaryReportRepository.GetSummaryReport()
            //    .Where(x => x.Date.Date >= Convert.ToDateTime(datumOd).Date
            //    && x.Date.Date <= Convert.ToDateTime(datumDo).Date).ToList();

            var sum = summaryRepurchaseRepository.GetSummaryReportRepurchase(Convert.ToDateTime(datumOd), Convert.ToDateTime(datumDo));
            var summaryReportDto = mapper.Map<IEnumerable<Models.SummaryReportRepurchase>>(sum);

            return summaryReportDto.ToList();
        }
        public void SaveChanges()
        {
            summaryRepurchaseRepository.SaveChanges();
        }

        public void UpdateRepurchase(SummaryReportRepurchase summaries)
        {
            var summariesDB = mapper.Map<DBModel.Models.SummaryReportRepurchase>(summaries);
            summaryRepurchaseRepository.Update(summariesDB);
        }
    }
}
