using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBModel.Models
{
  public  class Plot
    {
        public int PlotId { get; set; }
        [MaxLength(200)]
        public string PlotName { get; set; }
        [MaxLength(200)]
        public string PlotLabel { get; set; }
    }
}
