using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MediaItem_Example.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DataContext") { }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}