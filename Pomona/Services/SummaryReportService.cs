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
    public class SummaryReportService : ISummaryReportService
    {
        private readonly ISummaryReportRepository summaryReportRepository;
        private readonly IMapper mapper;
        public SummaryReportService(ISummaryReportRepository summaryReportRepository, IMapper mapper)
        {
            this.summaryReportRepository = summaryReportRepository;
            this.mapper = mapper;
        }
        public List<SummaryReport> GetSummaryReport()
        {
            var summaryReport = summaryReportRepository.GetSummaryReport();
            var summaryReportDto = mapper.Map<IEnumerable<Models.SummaryReport>>(summaryReport);
         
            return summaryReportDto.ToList();
        }

        public List<SummaryReport> GetSummaryReport(String datumOd,String datumDo)
        {
            //var summaryReport = summaryReportRepository.GetSummaryReport()
            //    .Where(x => x.Date.Date >= Convert.ToDateTime(datumOd).Date
            //    && x.Date.Date <= Convert.ToDateTime(datumDo).Date).ToList();

            var sum = summaryReportRepository.GetSummaryReport(Convert.ToDateTime(datumOd), Convert.ToDateTime(datumDo));
            var summaryReportDto = mapper.Map<IEnumerable<Models.SummaryReport>>(sum);

            return summaryReportDto.ToList();
        }
    }
}
