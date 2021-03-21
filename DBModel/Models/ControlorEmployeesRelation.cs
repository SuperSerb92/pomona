using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBModel.Models
{
   public class ControlorEmployeesRelation
    {

        //public User User { get; set; }
        //public Employee Employee { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

    }
}
