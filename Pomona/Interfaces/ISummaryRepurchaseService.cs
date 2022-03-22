using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Interfaces
{
   public interface ISummaryRepurchaseService
    {
      
        List<Models.SummaryReportRepurchase> GetSummaryReportRepurchase(String datumOd, String datumDo);

        void UpdateRepurchase(Models.SummaryReportRepurchase summaries);
        void SaveChanges();
    }
}
