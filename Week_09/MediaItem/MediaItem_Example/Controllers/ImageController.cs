using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediaItem_Example.Models;

namespace MediaItem_Example.Controllers
{
    public class ImageController : Controller
    {
        Manager m = new Manager();
        //
        // GET: /Image/
        public ActionResult Index()
        {
            return RedirectToAction("Vehicle", "Home");
        }

        public ActionResult Vehicle(int? id)
        {
            // Extract the number from the passed-in argument
            int lookup = id.GetValueOrDefault();

            // Attempt to fetch the vehicle
            var v = m.GetVehicleById(lookup);

            if (v == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Return a FileContentResult...
                // Return the photo bytes, and set the Content-Type header
                return File(v.Photo, v.PhotoType);
            }
        }
	}
}