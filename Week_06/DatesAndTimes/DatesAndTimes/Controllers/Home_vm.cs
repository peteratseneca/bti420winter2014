using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;

namespace DatesAndTimes.Controllers
{
    public class ProductAdd
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must range from {2} to {1} characters")]
        [Display(Name = "Product name")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed {1} characters")]
        // The following causes an HTML textarea element to be rendered
        [DataType(DataType.MultilineText)]
        [Display(Name = "Brief description")]
        public string Description { get; set; }

        [Range(0.5, 5000.0, ErrorMessage = "Sell price must range from {1:C} to {2:C}")]
        [Display(Name = "Retail selling price")]
        public double MSRP { get; set; }

        [Display(Name = "Date released for public sale")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime DateReleased { get; set; }

        [Display(Name = "Date and time of most recent update")]
        [DisplayFormat(DataFormatString = "{0:f}")]
        public DateTime? DateOfMostRecentUpdate { get; set; }

        [Display(Name = "Date retired/discontinued")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime? DateRetired { get; set; }
    }

    public class ProductBase : ProductAdd
    {
        public int Id { get; set; }
    }

    public class ProductViewer
    {
        [Display(Name = "Identifier")]
        public int Id { get; set; }

        [Display(Name = "Product name")]
        public string Name { get; set; }
        [Display(Name = "Brief description")]
        public string Description { get; set; }

        [Display(Name = "Retail selling price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double MSRP { get; set; }

        [Display(Name = "Date released for public sale")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime DateReleased { get; set; }

        [Display(Name = "Support end date")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime DateSupportEnds { get; set; }

        [Display(Name = "Date and time of most recent update")]
        [DisplayFormat(DataFormatString = "{0:f}")]
        public DateTime? DateOfMostRecentUpdate { get; set; }

        [Display(Name = "Date retired/discontinued")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime? DateRetired { get; set; }
    }

}
