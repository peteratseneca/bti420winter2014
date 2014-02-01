using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.Data.Entity;

namespace Lab4.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DataContext") { }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
