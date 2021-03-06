using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Models
{
    public class Culture
    {
        public int IdCulture { get; set; }
        public string CultureName { get; set; }
        public CultureType CultureType { get; set; }
    }
}
