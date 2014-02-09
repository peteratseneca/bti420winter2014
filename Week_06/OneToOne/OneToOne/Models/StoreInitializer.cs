using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.Data.Entity;

namespace OneToOne.Models
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

            // Add some addresses

            // Notice that you must configure the "Required" property
            // for this kind of one-to-one relationship

            // Notice that some of the addresses were intentionally left unconfigured
            // This enables the view to test for null and display an appropriate message

            marylynn.HomeAddress = new Address() { AddressLine1 = "123 Main Street", CityAndProvince = "Markham, ON", PostalCode = "L5H8B2", Employee = marylynn };
            marylynn.WorkAddress = new Address() { AddressLine1 = "School of ICT", AddressLine2 = "70 The Pond Road", CityAndProvince = "Toronto, ON", PostalCode = "M3J3M6", Employee = marylynn };

            peter.HomeAddress = new Address() { AddressLine1 = "123 Main Street", CityAndProvince = "Markham, ON", PostalCode = "L5H8B2", Employee = peter };
            peter.WorkAddress = new Address() { AddressLine1 = "School of ICT", AddressLine2 = "70 The Pond Road", CityAndProvince = "Toronto, ON", PostalCode = "M3J3M6", Employee = peter };

            //elliott.HomeAddress = new Address() { AddressLine1 = "123 Main Street", CityAndProvince = "Markham, ON", PostalCode = "L5H8B2", Employee = elliott };
            //elliott.WorkAddress = new Address() { AddressLine1 = "School of ICT", AddressLine2 = "70 The Pond Road", CityAndProvince = "Toronto, ON", PostalCode = "M3J3M6", Employee = elliott };

            //barb.HomeAddress = new Address() { AddressLine1 = "123 Main Street", CityAndProvince = "Markham, ON", PostalCode = "L5H8B2", Employee = barb };
            barb.WorkAddress = new Address() { AddressLine1 = "School of ICT", AddressLine2 = "70 The Pond Road", CityAndProvince = "Toronto, ON", PostalCode = "M3J3M6", Employee = barb };

            junlian.HomeAddress = new Address() { AddressLine1 = "123 Main Street", CityAndProvince = "Markham, ON", PostalCode = "L5H8B2", Employee = junlian };
            //junlian.WorkAddress = new Address() { AddressLine1 = "School of ICT", AddressLine2 = "70 The Pond Road", CityAndProvince = "Toronto, ON", PostalCode = "M3J3M6", Employee = junlian };

            context.SaveChanges();
        }
    }
}
