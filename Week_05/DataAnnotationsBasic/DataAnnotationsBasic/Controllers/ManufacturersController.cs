using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAnnotationsBasic.Controllers
{
    public class ManufacturersController : Controller
    {
        // Create a reference to the 'manager' object
        private Manager m = new Manager();

        //
        // GET: /Manufacturers/
        public ActionResult Index()
        {
            return View(m.GetAllManufacturers());
        }

        //
        // GET: /Manufacturers/Details/5
        public ActionResult Details(int id)
        {
            // Attempt to fetch the desired object
            var fetchedObject = m.GetManufacturerById(id);

            if (fetchedObject == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(fetchedObject);
            }
        }

        // ############################################################

        //
        // GET: /Manufacturers/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Manufacturers/Create
        [HttpPost]
        public ActionResult Create(ManufacturerAdd newItem)
        {
            if (ModelState.IsValid)
            {
                ManufacturerBase addedItem = m.AddManufacturer(newItem);
                // Should probably do a quick if-null test 
                return RedirectToAction("details", new { id = addedItem.Id });
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        // ############################################################

        //
        // GET: /Manufacturers/Edit/5
        public ActionResult Edit(int id)
        {
            // Attempt to get the object with the matching identifier
            ManufacturerBase fetchedObject = m.GetManufacturerById(id);

            if (fetchedObject == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(fetchedObject);
            }
        }

        //
        // POST: /Manufacturers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ManufacturerBase newItem)
        {
            // Two tests are required...
            if (ModelState.IsValid & id == newItem.Id)
            {
                // Attempt to update the item
                ManufacturerBase editedItem = m.EditManufacturer(newItem);

                if (editedItem == null)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    return RedirectToAction("details", new { id = editedItem.Id });
                }
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        // ############################################################

        //
        // GET: /Manufacturers/Delete/5
        public ActionResult Delete(int? id)
        {
            // The type of the parameter above was changed to int?, a nullable int
            // This will suppress an error message

            return View();
        }

        /*
        //
        // POST: /Manufacturers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
