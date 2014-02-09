using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.Data.Entity;

namespace OneToOne.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DataContext") { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
