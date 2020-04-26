using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAPI.Classes
{
    public class GameQueryParameters : QueryParameters
    {
        public int? Score { get; set; }
        public int? Player { get; set; }
    }
}
