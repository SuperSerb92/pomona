using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBModel.Models
{
   public class Group
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string GroupName { get; set; }
    }
}
