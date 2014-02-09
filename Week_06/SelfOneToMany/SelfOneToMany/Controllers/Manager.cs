using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using SelfOneToMany.Models;

namespace SelfOneToMany.Controllers
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

    }

}
