using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Personalize.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // We'll create a new Person object, and pass it to the Index view

            // Create the new Person object, using one of the syntax forms below:

            Person peter = new Person();
            peter.Id = 1;
            peter.GivenNames = "Peter";
            peter.LastName = "McIntyre";
            peter.Age = 29;

            Person elliott = new Person() { Id = 2, GivenNames = "Elliott", LastName = "Coleshill", Age = 29 };

            // Pass one of these objects to the view

            return View(peter);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Personalize web app example";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact your BTI420 professors";

            return View();
        }
    }
}