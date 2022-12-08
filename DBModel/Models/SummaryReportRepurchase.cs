using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Models
{
    public class SummaryReportRepurchase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Buyer { get; set; }
        public decimal Net { get; set; }
        public decimal NetBuyed { get; set; }
        public decimal NetDifference { get; set; }
        public decimal Price { get; set; }
        public decimal Income { get; set; }
        public decimal IncomeEur { get; set; }
        public int NoOfBoxes { get; set; }
        public bool? Paid { get; set; }
        public DateTime? PaidDate { get; set; }
        public string Comment { get; set; }
        public string CultureName { get; set; }
    }
}
