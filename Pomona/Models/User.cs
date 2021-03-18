using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Models
{
    public class User
    {    
        [Key]
        public int UserID { get; set; }
        [MaxLength(200)]
        public string FirstName { get; set; }
        [MaxLength(200)]
        public string LastName { get; set; }

        [MaxLength(200)]
        public string UserName { get; set; }
        [MaxLength(200)]
        public string Password { get; set; }
        [MaxLength(200)]
        public string RepeatedPassword { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        [MaxLength(200)]
        public string FarmName { get; set; }
        [MaxLength(200)]
        public string FarmNo { get; set; }       
        public int IdGroup { get; set; }

        public int IndLogged { get; set; }

    }
}
