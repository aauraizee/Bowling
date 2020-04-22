using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAPI.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public int TotalScore { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
