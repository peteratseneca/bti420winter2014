using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaItem_Example.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public int Year { get; set; }
        public int MSRP { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoType { get; set; }
    }
}