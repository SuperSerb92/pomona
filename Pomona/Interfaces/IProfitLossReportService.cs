using Pomona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Interfaces
{
   public interface IProfitLossReportService
    {
        List<Models.ProfitLossReport> GetProfitLossReport(String datumOd, String datumDo);
        decimal GetAvgPrice(string datumOd, string datumDo);
    }
}
