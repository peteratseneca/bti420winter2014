using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using OneToOne.Models;

namespace OneToOne.Controllers
{
    public class Manager
    {
        DataContext ds = new DataContext();

        // ############################################################
        // Employees

        public IEnumerable<EmployeeBase> GetAllEmployees()
        {
            // Fetch from the persistent store
            var fetchedObjects =
                ds.Employees
                .OrderBy(ln => ln.LastName)
                .ThenBy(gn => gn.GivenNames);

            // Prepare and return the view model objects
            return Mapper.Map<IEnumerable<EmployeeBase>>(fetchedObjects);
        }

        public IEnumerable<EmployeeBaseWithEmployees> GetAllEmployeesWithEmployees()
        {
            // Fetch from the persistent store
            var fetchedObjects =
                ds.Employees
                .Include("EmployeesSupervised")
                .Include("ReportsToEmployee")
                .OrderBy(ln => ln.LastName)
                .ThenBy(gn => gn.GivenNames);

            // Prepare and return the view model objects
            return Mapper.Map<IEnumerable<EmployeeBaseWithEmployees>>(fetchedObjects);
        }

        public EmployeeBaseWithAddresses GetEmployeeWithAddressesById(int id)
        {
            // Fetch from the persistent store
            var fetchedObject =
                ds.Employees
                .Include("HomeAddress")
                .Include("WorkAddress")
                .SingleOrDefault(eid => eid.Id == id);

            // Prepare and return the view model object
            return fetchedObject == null
                ? null
                : Mapper.Map<EmployeeBaseWithAddresses>(fetchedObject);
        }

        // ############################################################
        // Addresses

        public AddressBase GetAddressByEmployeeId(int employeeId)
        {
            // Fetch from the persistent store
            var fetchedObject = ds.Addresses.SingleOrDefault(eid => eid.EmployeeId == employeeId);

            // Prepare and return the view model object
            return fetchedObject == null ? null : Mapper.Map<AddressBase>(fetchedObject);
        }

    }

}
