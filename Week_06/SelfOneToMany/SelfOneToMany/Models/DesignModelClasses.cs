using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;

namespace SelfOneToMany.Models
{
    public class Employee
    {
        public Employee()
        {
            this.EmployeesSupervised = new List<Employee>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string GivenNames { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        // Include an int property to hold the identifier of the referenced object
        // It must be nullable, because it is optional (in many real-life situations)
        public int? ReportsToEmployeeId { get; set; }
        // Next, include a navigation property to reference this class
        public Employee ReportsToEmployee { get; set; }

        // Finally, include the 'other' side of the association
        // An employee who is a supervisor has a collection
        // of employees who report this supervisor
        public ICollection<Employee> EmployeesSupervised { get; set; }
    }

}
