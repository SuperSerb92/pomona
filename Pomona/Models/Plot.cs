using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Models
{
    public class Plot
    {
        public int PlotId { get; set; }
        [MaxLength(200)]
        public string PlotName { get; set; }
        [MaxLength(200)]
        public string PlotLabel { get; set; }
        public int PlotListId { get; set; }

        public PlotList PlotList { get; set; }
    }
}
