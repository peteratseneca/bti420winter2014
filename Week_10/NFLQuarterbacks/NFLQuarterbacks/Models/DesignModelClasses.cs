using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NFLQuarterbacks.Models
{
    public class Quarterback
    {
        public int Id { get; set; }
        public int Rank { get; set; }
        public string Player { get; set; }
        public string Team { get; set; }
        public string Conference { get; set; }
        public int Completions { get; set; }
        public int Attempts { get; set; }
        public int Yards { get; set; }
        public int Touchdowns { get; set; }
        public int Interceptions { get; set; }
        public int Sacks { get; set; }
        public double Rating { get; set; }
        public string PhotoUrl { get; set; }
    }

}
