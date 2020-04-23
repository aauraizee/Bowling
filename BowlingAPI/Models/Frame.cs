using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BowlingAPI.Models
{
    public class Frame
    {
        //X=Strike, S=Spare, O=Open, T=Tenth
        public enum FrameType
        {
            X,
            S,
            O,
            T
        }
        public int FrameId { get; set; }
        public int Value { get; set; }
        public FrameType TypeFlag { get; set; }

        public int GameId { get; set; }

        [JsonIgnore]
        public Game Game { get; set; }

        [JsonIgnore]
        public ICollection<Shot> Shots { get; set; }
    }
}
