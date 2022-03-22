using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Interfaces
{
  public interface ISummaryReportRepository
    {
        IEnumerable<SummaryReport> GetSummaryReport();
        IEnumerable<SummaryReport> GetSummaryReport(DateTime datumOd, DateTime datumDo);
    }
}
