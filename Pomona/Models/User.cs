using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Models
{
    public class User
    {
       public int UserID { get; set; }
       public string UserName { get; set; }
       public string Password { get; set; }
        public string RepeatedPassword { get; set; }
        public string Email { get; set; }
        public string FarmName { get; set; }
        public string FarmNo { get; set; }
        public int IdGroup { get; set; }


    }
}
