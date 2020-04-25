using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAPI.Classes
{
    public class FrameQueryParameters : QueryParameters
    {
        private int _type = -1;

        public int? Game { get; set; }
        public int? Value { get; set; }
        public int? Type { get; set; }
    }
}
