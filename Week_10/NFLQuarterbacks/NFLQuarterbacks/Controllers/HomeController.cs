using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFLQuarterbacks.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Import from CSV.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact info.";

            return View();
        }
    }
}