using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.Data.Entity;

namespace Lab4.Models
{
    public class StoreInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    //public class StoreInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            // Data source was Wikipedia

            var nike = new Supplier();
            nike.Name = "Nike, Inc.";
            context.Suppliers.Add(nike);

            context.SaveChanges();
        }
    }
}
