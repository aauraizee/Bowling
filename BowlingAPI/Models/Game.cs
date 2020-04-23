using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BowlingAPI.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public int TotalScore { get; set; }
        public int PlayerId { get; set; }

        [JsonIgnore]
        public Player Player { get; set; }

        [JsonIgnore]
        public ICollection<Frame> Frames { get; set; }
    }
}
