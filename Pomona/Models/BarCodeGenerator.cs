using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Models
{
    public class BarCodeGenerator
    {
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int PlotId { get; set; }
        public Plot Plot { get; set; }
        public int CultureTypeId { get; set; }
        public CultureType CultureType { get; set; }
        public int CultureId { get; set; }
        public Culture Culture { get; set; }
        public int PackagingId { get; set; }
        public Packaging Packaging { get; set; }
        public string BarCode { get; set; }
        public int Rbr { get; set; }
        public DateTime DateGenerated { get; set; }
        /// <summary>
        /// //0 nije 1 jeste
        /// </summary>
        public int IndStorn { get; set; }
        public int Status { get; set; }

        public string StatusDisplay { get; set; }

        public int Tara { get; set; }

    }
}
