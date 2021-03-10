using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBModel.Models
{
  public  class Buyer
    {
        public int BuyerId { get; set; }
        [MaxLength(50)]
        public string BuyerName { get; set; }
        [MaxLength(50)]
        public string Pib { get; set; }
        [MaxLength(20)]
        public string Jmbf { get; set; }
        [MaxLength(20)]
        public string BuyerPhoneNumber { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
