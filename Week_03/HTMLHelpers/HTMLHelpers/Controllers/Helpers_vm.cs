using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTMLHelpers.Controllers
{
    public class LoginData
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Product
    {
        public Product()
        {
            this.Colours = new List<string>();
        }

        public int Id { get; set; }
        public string Name { get; set; }                    // Short name
        public string Description { get; set; }             // Longer description
        public string Size { get; set; }                    // e.g. Small, Medium, Large
        public ICollection<string> Colours { get; set; }    // zero or more; e.g. Red, Green, Blue
    }

    public class ProductWithSize : Product
    {
        public ProductWithSize()
        {
            this.Sizes = new List<string>() { "Small", "Medium", "Large" };
        }

        public ICollection<string> Sizes { get; set; }
    }

    public class ProductWithColours : Product
    {
        public ProductWithColours()
        {
            this.Colours = new List<string>() { "Red", "Green", "Blue", "Yellow", "Brown", "Purple", "White", "Orange" };
        }

        public ICollection<string> Colours { get; set; }
    }

}
