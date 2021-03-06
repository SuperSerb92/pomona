using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Models
{
    public class TreeItemsPomona : System.Collections.ObjectModel.Collection<TreeItemPomona>
    {
        public static TreeItemsPomona TreeItems = new TreeItemsPomona() {
             new TreeItemPomona {
                ID = 1,
                ParentId = 0,
                ImageUrl = "../../images/Pomona/Diskovi.png",
                Text = "Šifarnici",
               // Icon = "home",
                Expanded = true
            },
               new TreeItemPomona {
                ID = 2,
                ParentId = 1,
                ImageUrl = "../../images/Pomona/Diskovi.png",
                Text ="Radnici",
               //  Icon = "home",
                Expanded = true
            },
            new TreeItemPomona {
                ID = 3,
                ParentId = 1,
                ImageUrl = "../../images/Pomona/Diskovi.png",
                Text ="Kontrolori",
               //  Icon = "home",
                Expanded = true
            },
                 new TreeItemPomona {
                ID = 4,
                ParentId = 1,
                ImageUrl = "../../images/Pomona/Diskovi.png",
                Text ="Otkupljivači",
                Expanded = true
            },
            new TreeItemPomona {
                ID = 5,
                ParentId = 1,
                ImageUrl = "../../images/Pomona/Diskovi.png",
                Text = "Redovi parcele",
                Expanded = true
            },
            new TreeItemPomona {
                ID = 6,
                ParentId = 1,
                ImageUrl = "../../images/Pomona/Diskovi.png",
                Text ="Vrsta voća",
                Expanded = true
            },
            new TreeItemPomona {
                ID = 7,
                ParentId = 1,
                ImageUrl = "../../images/Pomona/Diskovi.png",
                Text ="Sorta voća",
                Expanded = true
            },
           new TreeItemPomona {
                ID = 8,
                ParentId = 1,
                ImageUrl = "../../images/Pomona/Diskovi.png",
                Text ="Tip ambalaže",
                Expanded = true
            },
             new TreeItemPomona {
                ID = 9,
                ParentId = 1,
                ImageUrl = "../../images/Pomona/Diskovi.png",
                Text ="Generisanje barcode-a",
                Expanded = true
            },
               new TreeItemPomona {
                ID = 10,
                ParentId = 1,
                ImageUrl = "../../images/Pomona/Diskovi.png",
                Text ="Očitavanje barcode-a",
                Expanded = true
            },
                  new TreeItemPomona {
                ID = 11,
                ParentId = 0,
                ImageUrl = "../../images/Pomona/Diskovi.png",
                Text ="Izveštaji",
                Expanded = true
            },
                       new TreeItemPomona {
                ID = 12,
                ParentId = 11,
                ImageUrl = "../../images/Pomona/Diskovi.png",
                Text ="Evidentiranje ocene radnika",
                Expanded = true
            },
                 new TreeItemPomona {
                ID = 13,
                ParentId = 11,
                ImageUrl = "../../images/Pomona/Diskovi.png",
                Text ="Sumarni izveštaj",
                Expanded = true
            }
        };
    }
}
