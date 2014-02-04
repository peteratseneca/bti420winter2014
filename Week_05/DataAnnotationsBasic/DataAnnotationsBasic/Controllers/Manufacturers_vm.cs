using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsBasic.Controllers
{
    // To be used in a user interface list/selection control
    public class ManufacturerList
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // Supports the 'add new' task
    // Can be sent to the HTML Form, and received from the HTML Form
    public class ManufacturerAdd
    {
        [Required]
        [StringLength(200)]
        [Display(Name="Manufacturer Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Head office country")]
        public string Country { get; set; }
        [Range(1850,2500)]
        [Display(Name = "Year the company was started")]
        public int YearStarted { get; set; }
    }

    // Supports common 'get' tasks
    // Inherits from the class above
    public class ManufacturerBase : ManufacturerAdd
    {
        public int Id { get; set; }
    }

}
