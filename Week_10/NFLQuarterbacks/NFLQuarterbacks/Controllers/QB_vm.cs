using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;

namespace NFLQuarterbacks.Controllers
{
    public class QuarterbackAdd
    {
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
        [DisplayFormat(DataFormatString="{0:N1}")]
        public double Rating { get; set; }
        [Display(Name="Photo")]
        public string PhotoUrl { get; set; }
    }

    public class QuarterbackBase : QuarterbackAdd
    {
        public int Id { get; set; }
    }

}
