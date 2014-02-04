using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsBasic.Models
{
    // This source code file holds classes that describe the design model entities

    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Vehicles = new List<Vehicle>();
            // A design model class cannot use the [Required] attribute
            // for a value property like 'YearStarted' (which is an int)
            // A work-around is to assign it a reasonable starting value
            this.YearStarted = DateTime.Now.Year;
        }

        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Country { get; set; }
        public int YearStarted { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }

    public class Vehicle
    {
        public Vehicle()
        {
            this.ModelYear = DateTime.Now.Year;
            this.MSRP = 20000;
        }

        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Model { get; set; }
        [Required]
        [StringLength(100)]
        public string Trim { get; set; }
        public int ModelYear { get; set; }
        public int MSRP { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }

}
