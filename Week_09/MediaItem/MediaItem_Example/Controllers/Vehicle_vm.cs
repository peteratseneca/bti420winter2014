using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaItem_Example.Controllers
{
    public class AddVehicleForm
    {
        public string Model { get; set; }
        public string Trim { get; set; }
        public int Year { get; set; }
        public int MSRP { get; set; }
    }

    public class AddVehicle
    {
        public string Model { get; set; }
        public string Trim { get; set; }
        public int Year { get; set; }
        public int MSRP { get; set; }

        public HttpPostedFileBase PhotoUpload { get; set; }
    }

    public class VehicleBase : AddVehicle
    {
        public int Id { get; set; }
        public byte[] Photo { get; set; }       //This gets automatically set in the POST controller method
        public string PhotoType { get; set; }   //This gets automatically set in the POST controller method 
    }
}