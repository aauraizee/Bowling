using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAPI.Models
{
    public class Shot
    {
        public int ShotId { get; set; }
        public int PinsHit { get; set; }
        public bool IsSpareShot { get; set; }
        public string SpareType { get; set; }
        public bool WasConverted { get; set; }
        public int FrameId { get; set; }
        public Frame Frame { get; set; }
    }
}
