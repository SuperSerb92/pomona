using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Models
{
    public class CultureType
    {
        //todo uros dal l je  dobro ovo oko odnosa
        public int CultureTypeId { get; set; }
        public string CultureTypeName { get; set; }

       [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CultureId")]
        public int? CultureId { get; set; }
        public Culture Culture { get; set; }
    }
}
