using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Interfaces
{
   public interface IProfitLossReportRepository
    {
        IEnumerable<ProfitLossReport> GetProfitLossReport(DateTime datumOd, DateTime datumDo);
        decimal GetAvgPrice(string datumOd, string datumDo);
    }
}
