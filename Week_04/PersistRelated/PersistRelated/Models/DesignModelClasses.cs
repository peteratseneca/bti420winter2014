using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersistRelated.Models
{
    // This source code file holds classes that describe the design model entities

    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Vehicles = new List<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int YearStarted { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }

    public class Vehicle
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public int ModelYear { get; set; }
        public int MSRP { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }

}
