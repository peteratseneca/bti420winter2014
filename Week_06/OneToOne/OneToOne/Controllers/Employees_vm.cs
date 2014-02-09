using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;

namespace OneToOne.Controllers
{
    public class EmployeeBase
    {
        public int Id { get; set; }
        public string GivenNames { get; set; }
        public string LastName { get; set; }
        public int? ReportsToEmployeeId { get; set; }
        public EmployeeBase ReportsToEmployee { get; set; }
    }

    public class EmployeeBaseWithEmployees : EmployeeBase
    {
        public ICollection<EmployeeBase> EmployeesSupervised { get; set; }
    }

    public class EmployeeBaseWithAddresses : EmployeeBase
    {
        public AddressBase HomeAddress { get; set; }
        public AddressBase WorkAddress { get; set; }
    }

    public class AddressBase
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string CityAndProvince { get; set; }
        public string PostalCode { get; set; }

        public int? EmployeeId { get; set; }
        public EmployeeBase Employee { get; set; }
    }

}
