using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.Web.Mvc;

namespace PersistRelated.Controllers
{
    // Design philosophy:
    // Deliver only what's needed for a 'select' user interface control
    public class VehicleList
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
    }

    // Design philosophy:
    // Prepare the model for the HTML Form
    public class VehicleAddForm
    {
        public string Model { get; set; }
        public string Trim { get; set; }
        public int ModelYear { get; set; }
        public int MSRP { get; set; }
        // SelectList, for a drop-down list
        public SelectList Manufacturers { get; set; }
    }

    // Design philosophy:
    // Gather input data from a user
    public class VehicleAdd
    {
        public string Model { get; set; }
        public string Trim { get; set; }
        public int ModelYear { get; set; }
        public int MSRP { get; set; }
        public int ManufacturerId { get; set; }
    }

    // Design philosophy:
    // Build on the class above, by inheritance
    // A 'base' view model class includes the identifier property
    // And anything else you think may be useful
    public class VehicleBase : VehicleAdd
    {
        public int Id { get; set; }
        public string ManufacturerName { get; set; }
    }

    // Design philosophy:
    // Build on the class above, by inheritance
    // This class includes the related object
    public class VehicleBaseWithManufacturer : VehicleBase
    {
        public ManufacturerBase Manufacturer { get; set; }
    }

}
