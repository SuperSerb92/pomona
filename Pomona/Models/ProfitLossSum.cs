using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Models
{
    public class ProfitLossSum
    {
        string naziv;
        decimal procenat;
        string proc;
        public decimal Procenat { get => procenat; set => procenat = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Proc { get => proc; set => proc = value; }
    }
}
