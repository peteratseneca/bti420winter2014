using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Models
{
    public class Supplier
    {
        public Supplier()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        // Read the specifications

        public ICollection<Product> Products { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Read the specifications

        public Supplier Supplier { get; set; }
    }

}
