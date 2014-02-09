using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;

namespace OneToOne.Models
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

        // This is the "principal" end of the Employee-Address association
        public Address HomeAddress { get; set; }
        public Address WorkAddress { get; set; }
    }

    // An employee can optionally have address properties (principal)
    // An address MUST be associated with an employee (dependent)

    public class Address
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        [StringLength(100)]
        public string CityAndProvince { get; set; }
        [Required]
        [StringLength(20)]
        public string PostalCode { get; set; }

        public int? EmployeeId { get; set; }
        // This is the "dependent" end of the Employee-Address association
        [Required]
        public Employee Employee { get; set; }
    }

}
