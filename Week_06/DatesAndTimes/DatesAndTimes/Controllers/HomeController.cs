using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// new...
using AutoMapper;

namespace DatesAndTimes.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            // Configure AutoMapper maps
            Mapper.CreateMap<ProductAdd, ProductBase>();
            Mapper.CreateMap<ProductBase, ProductViewer>();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Working with dates and times.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "BTI420 Faculty.";

            return View();
        }

        // ############################################################
        // Hard coded

        public ActionResult HardCoded()
        {
            // Do some date manipulation in code
            // We will pass a Dictionary data structure to the view

            var results = new Dictionary<string, string>();

            // Now property - current date and time
            var timeStamp = DateTime.Now;
            results.Add ("Current timestamp, long strings", 
                string.Format("{0} at {1}", 
                timeStamp.ToLongDateString(), 
                timeStamp.ToLongTimeString()));

            // Formatted with short date and time strings
            results.Add("Above, short strings",
                string.Format("{0} at {1}",
                timeStamp.ToShortDateString(),
                timeStamp.ToShortTimeString()));

            // Using standard date and time format string
            // http://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx
            results.Add("Above, 'f' format specifier", timeStamp.ToString("f"));

            // Using custom date and time format string
            // http://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
            results.Add("Above, custom", timeStamp.ToString("dddd, MMMM dd, yyyy ' at ' h ' and ' m ' in the ' tt"));

            // Date arithmetic

            var tshours = timeStamp.AddHours(15);
            results.Add("Now plus 15 hours", tshours.ToString("f"));

            var tsdays = timeStamp.AddDays(4);
            results.Add("Now plus 4 days", tsdays.ToString("f"));

            var tsmonths = timeStamp.AddMonths(7);
            results.Add("Now plus 7 months", tsmonths.ToString("f"));

            // Create a new date and time in the future
            var newDT = new DateTime(2015, 8, 23, 11, 38, 40);
            results.Add("Future date", newDT.ToString("F"));

            // Date arithmetic
            TimeSpan difference = newDT - timeStamp;

            results.Add("Days from now", difference.TotalDays.ToString("#,##0"));
            results.Add("Minutes from now", difference.TotalMinutes.ToString("#,##0"));

            return View(results);
        }

        // ############################################################
        // Add new

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductAdd newItem)
        {
            if (ModelState.IsValid)
            {
                // Create a product item
                var addedItem = Mapper.Map<ProductBase>(newItem);

                // Configure some of its values
                addedItem.Id = 23;
                addedItem.DateOfMostRecentUpdate = DateTime.Now;

                // Save to session state
                Session["product"] = addedItem;

                // Show its details
                return RedirectToAction("details", new { id = addedItem.Id });
            }
            else
            {
                return View(newItem);
            }
        }

        // ############################################################
        // Details

        public ActionResult Details(int id)
        {
            // Doesn't matter what value was passed in, fetch from session state
            ProductBase fetchedObject;
            if (Session["product"] == null)
            {
                return RedirectToAction("create");
            }
            else
            {
                // Get the object
                fetchedObject = Session["product"] as ProductBase;

                // Configure some values
                var viewerObject = Mapper.Map<ProductViewer>(fetchedObject);
                viewerObject.DateSupportEnds = viewerObject.DateReleased.AddMonths(18);

                return View(viewerObject);
            }
        }

        // ############################################################
        // Edit

        public ActionResult Edit(int id)
        {
            // Doesn't matter what value was passed in, fetch from session state
            ProductBase fetchedObject;
            if (Session["product"] == null)
            {
                return RedirectToAction("create");
            }
            else
            {
                fetchedObject = Session["product"] as ProductBase;
                return View(fetchedObject);
            }

        }

        [HttpPost]
        public ActionResult Edit(int id, ProductBase newItem)
        {
            if (ModelState.IsValid)
            {
                // Configure some of its values
                newItem.DateOfMostRecentUpdate = DateTime.Now;

                // Save to session state
                Session["product"] = newItem;

                // Show its details
                return RedirectToAction("details", new { id = newItem.Id });
            }
            else
            {
                return View(newItem);
            }
        }

    }
}