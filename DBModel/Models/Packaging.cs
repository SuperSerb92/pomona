using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBModel.Models
{
  public  class Packaging
    {
        public int PackagingId { get; set; }
        [MaxLength(200)]
        public string PackagingType { get; set; }
        public int Tara { get; set; }
    }
}
