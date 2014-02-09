using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;

namespace SelfOneToMany.Controllers
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

}
