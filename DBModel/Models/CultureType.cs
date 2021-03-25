using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBModel.Models
{
   public class CultureType
    {
        public int CultureId { get; set; }
        public int CultureTypeId { get; set; }
        [MaxLength(200)]
        public string CultureTypeName { get; set; }
        public Culture Culture { get; set; }
    }
}
