using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityUsersAndRoles.Controllers
{
    public class HomeController : Controller
    {
        private Manager m = new Manager();

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult AuthStatus()
        {
            // Attempt to fetch the user info object
            var userObject = m.GetUserInfo(User.Identity.Name);

            if (userObject==null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(userObject);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Security users and roles.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact info.";

            return View();
        }

    }
}