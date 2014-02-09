using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneToOne.Controllers
{
    public class EmployeesController : Controller
    {
        // Reference to the manager object
        private Manager m = new Manager();

        //
        // GET: /Employees/
        public ActionResult Index()
        {
            return View(m.GetAllEmployeesWithEmployees());
        }

        //
        // GET: /Employees/Details/5
        public ActionResult Details(int id = 0)
        {
            // Safe redirect
            if (id == 0) { return RedirectToAction("index"); }

            // Attempt to fetch the object
            var emp = m.GetEmployeeWithAddressesById(id);

            if (emp == null)
            {
                // You can return a generic error page...
                //return HttpNotFound();

                // ...or you can start learning about graceful error-handling
                emp = new EmployeeBaseWithAddresses() { GivenNames = string.Format("(Employee with identifier {0} was requested)", id), LastName = "(That employee does not exist)" };
                return View(emp);
            }
            else
            {
                return View(emp);
            }
        }

    }
}
