using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.Data.Entity;

namespace SelfOneToMany.Models
{
    //public class StoreInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    public class StoreInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            // Create some initial data

            // Employees

            var marylynn = new Employee() { GivenNames = "Mary Lynn", LastName = "Manton" };
            context.Employees.Add(marylynn);

            var peter = new Employee() { GivenNames = "Peter", LastName = "McIntyre" };
            context.Employees.Add(peter);

            var elliott = new Employee() { GivenNames = "Elliott", LastName = "Coleshill" };
            context.Employees.Add(elliott);

            var barb = new Employee() { GivenNames = "Barb", LastName = "Czegel" };
            context.Employees.Add(barb);

            var junlian = new Employee() { GivenNames = "Junlian", LastName = "Xiang" };
            context.Employees.Add(junlian);

            context.SaveChanges();

            // Set the associations

            // Can do it from the perspective of the supervisor...

            marylynn.EmployeesSupervised.Add(peter);
            marylynn.EmployeesSupervised.Add(elliott);

            // Can also do it from the perspective of the employee...

            barb.ReportsToEmployee = marylynn;
            junlian.ReportsToEmployee = marylynn;

            context.SaveChanges();

        }
    }
}
