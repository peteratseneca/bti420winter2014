using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4.Controllers
{
    public class SuppliersController : Controller
    {
        private Manager m = new Manager();

        //
        // GET: /Suppliers/
        public ActionResult Index()
        {
            // Return all suppliers
            return View();
        }

	}

}