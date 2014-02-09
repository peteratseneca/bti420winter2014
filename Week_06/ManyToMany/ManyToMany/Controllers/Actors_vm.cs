using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;

namespace ManyToMany.Controllers
{
    public class ActorBase
    {
        public int Id { get; set; }
        public string GivenNames { get; set; }
        public string LastName { get; set; }
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime BirthDate { get; set; }

        // Standard date and time format strings
        // d, D, m or M
        // http://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx 

        // Custom date and time format strings
        // After "0:", use y=year, M=month, d=day, h=hour, m=minute, s=second
        // http://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
    }

    public class ActorBaseWithMovies : ActorBase
    {
        // Make sure the propery name matches the name used in the design model
        public ICollection<MovieBase> Movies { get; set; }
    }

}
