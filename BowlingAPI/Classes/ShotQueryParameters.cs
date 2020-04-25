using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAPI.Classes
{
    public class ShotQueryParameters : QueryParameters
    {
        public int? Frame { get; set; }
        public int? Pins { get; set; }
        public bool? IsSpare { get; set; }
        public bool? Converted { get; set; }
        public string? SpareType { get; set; }
    }
}
