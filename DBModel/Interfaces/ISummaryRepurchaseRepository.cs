using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Interfaces
{
    public interface ISummaryRepurchaseRepository
    {
        IEnumerable<SummaryReportRepurchase> GetSummaryReportRepurchase(DateTime datumOd, DateTime datumDo);
        void Update(DBModel.Models.SummaryReportRepurchase summaries);
        void SaveChanges();
    }
}
