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
    public class ProfitLossReportService : IProfitLossReportService
    {
        private readonly IProfitLossReportRepository profitLossReportRepository;
        private readonly IMapper mapper;
        public ProfitLossReportService(IProfitLossReportRepository profitLossReportRepository, IMapper mapper)
        {
            this.profitLossReportRepository = profitLossReportRepository;
            this.mapper = mapper;
        }

        public decimal GetAvgPrice(string datumOd, string datumDo)
        {
            return profitLossReportRepository.GetAvgPrice(datumOd, datumDo);
        }

        public List<ProfitLossReport> GetProfitLossReport(string datumOd, string datumDo)
        {
            var sum = profitLossReportRepository.GetProfitLossReport(Convert.ToDateTime(datumOd).Date, Convert.ToDateTime(datumDo));           
            var profitLossReportDto = mapper.Map<IEnumerable<Models.ProfitLossReport>>(sum);
            foreach (var item in profitLossReportDto)
            {
                item.DatumBezVremena = item.Datum.ToShortDateString();
                item.TrosakS = item.Trosak.ToString("n0");
                item.PrihodS = item.Prihod.ToString("n0");
                item.ProfitS = item.Profit.ToString("n0");
            }
            return profitLossReportDto.ToList();
        }
    }
}
