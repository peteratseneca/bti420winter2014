using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsBasic.Controllers
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
        [Display(Name = "Vehicle's model name")]
        public string Model { get; set; }
        [Display(Name = "Trim name, level, or designation")]
        public string Trim { get; set; }
        [Display(Name = "Model year")]
        public int ModelYear { get; set; }
        [Display(Name = "Suggested retail price")]
        public int MSRP { get; set; }
        // SelectList, for a drop-down list
        [Display(Name = "Manufacturer name")]
        public SelectList Manufacturers { get; set; }
    }

    // Design philosophy:
    // Gather input data from a user
    public class VehicleAdd
    {
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage="Invalid name; must range between {2} and {1} characters")]
        [Display(Name = "Model name")]
        public string Model { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Invalid name; must range between {2} and {1} characters")]
        [Display(Name = "Trim level")]
        public string Trim { get; set; }
        [Range(1850, 2500)]
        [Display(Name = "Model year")]
        public int ModelYear { get; set; }
        [Range(5000, 500000, ErrorMessage="Value must range between ${1} and ${2}")]
        [Display(Name = "Retail price")]
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
        [Display(Name = "Manufacturer name")]
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
