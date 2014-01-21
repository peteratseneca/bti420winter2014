using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTMLFormElementsBuiltIn.Controllers
{
    public class HomeController : Controller
    {
        public Product widget { get; set; }
        public ProductWithSize widgetWithSize { get; set; }
        public ProductWithColours widgetWithColours { get; set; }

        public HomeController()
        {
            this.widget = new Product();
            this.widgetWithSize = new ProductWithSize();
            this.widgetWithColours = new ProductWithColours();
        }

        // ############################################################

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // ############################################################

        public ActionResult TextArea()
        {
            return View(widget);
        }

        public ActionResult SingleSelection()
        {
            return View(widgetWithSize);
        }

        public ActionResult MultiSelection()
        {
            return View(widgetWithColours);
        }

        [HttpPost]
        public ActionResult MultiSelection(ProductWithColours product)
        {
            // The multi selection posted results come back in 
            // as you would expect, a collection of strings
            string result = string.Join(", ", product.Colours.ToArray());
            return Content(result);
        }

    }

}