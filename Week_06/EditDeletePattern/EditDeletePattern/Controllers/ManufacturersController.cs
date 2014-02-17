using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EditDeletePattern.Controllers
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
                    // There was a problem updating the object
                    return View(newItem);
                }
                else
                {
                    // Succesful - item was edited
                    TempData["statusMessage"] = "Edits have been saved.";
                    return RedirectToAction("details", new { id = editedItem.Id });
                }
            }
            else
            {
                // Return the object so the user can edit it correctly
                return View(newItem);
            }
        }

        // ############################################################

        //
        // GET: /Manufacturers/Delete/5
        public ActionResult Delete(int? id)
        {
            // The type of the parameter above was changed to int?, a nullable int
            // This will suppress an error message

            // Attempt to fetch the object to be deleted
            // Notice that we must use a method on the nullable int
            ManufacturerBase itemToDelete = m.GetManufacturerById(id.GetValueOrDefault());

            if (itemToDelete == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(itemToDelete);
            }
        }

        //
        // POST: /Manufacturers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            // Attempt to delete the item
            if (m.DeleteManufacturerById(id))
            {
                // Succesful - item was deleted
                TempData["statusMessage"] = "This manufacturer was deleted.";
            }
            else
            {
                // Request was not successful
                TempData["statusMessage"] = "Unable to delete this manufacturer.";
            }
            return RedirectToAction("details", new { id = id });
        }
    }
}
