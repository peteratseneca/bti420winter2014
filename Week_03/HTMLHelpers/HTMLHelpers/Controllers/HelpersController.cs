using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTMLHelpers.Controllers
{
    public class HelpersController : Controller
    {
        //
        // GET: /Helpers/
        public ActionResult Index()
        {
            return View();
        }

        // ############################################################

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginData loginData)
        {
            TempData["loginData"] = loginData;

            return RedirectToAction("login");
        }

        // ############################################################

        public ActionResult Size()
        {
            return View(new ProductWithSize());
        }

        [HttpPost]
        public ActionResult Size(ProductWithSize product)
        {
            TempData["product"] = product;

            return RedirectToAction("size");
        }

        // ############################################################

	}

}
