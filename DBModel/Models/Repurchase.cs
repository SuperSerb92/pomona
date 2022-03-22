using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Models
{
   public class Repurchase
    {
        public int Id { get; set; }
        public int CultureId { get; set; }
        public DateTime Date { get; set; }
        public int BuyerId { get; set; }
        public decimal Neto { get; set; }
        public decimal NetoShipped { get; set; }
        public decimal Difference { get; set; }
        public decimal Price { get; set; }
        public decimal Income { get; set; }
    }
}
