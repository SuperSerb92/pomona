using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Models
{
    public class CultureType
    {
        public int IdCultureType { get; set; }
        public string CultureTypeName { get; set; }
        public Culture Culture { get; set; }
    }
}
