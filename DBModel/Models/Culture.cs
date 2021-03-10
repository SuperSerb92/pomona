using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBModel.Models
{
  public  class Culture
    {
        public int CultureId { get; set; }
        [MaxLength(200)]
        public string CultureName { get; set; }
    }
}
