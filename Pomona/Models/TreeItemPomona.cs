using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Models
{
    public class TreeItemPomona
    {
       public int ID { get; set; }
        public int ParentId { get; set; }
        public string ImageUrl { get; set; }
        public string Text { get; set; }
        public bool Expanded { get; set; }
        public string Icon { get; set; }
    }
}
