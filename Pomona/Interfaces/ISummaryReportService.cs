using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Interfaces
{
   public interface ISummaryReportService
    {
        List<Models.SummaryReport> GetSummaryReport();
        List<Models.SummaryReport> GetSummaryReport(String datumOd, String datumDo);
    }
}
