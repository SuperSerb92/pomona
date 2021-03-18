using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBModel.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
        public string Email { get; set; }
        public string FarmName { get; set; }
        public string FarmNo { get; set; }
        public int IdGroup { get; set; }
        public int IndLogged { get; set; }

        public string NameSurname { get { return FirstName + " " + LastName; } }

    }
}
