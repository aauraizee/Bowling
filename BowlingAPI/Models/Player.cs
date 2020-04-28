using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BowlingAPI.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public int GamesPlayed { get; set; }
        public int CurrentAverage { get; set; }

        [JsonIgnore]
        public ICollection<Game> Games { get; set; }
    }
}
