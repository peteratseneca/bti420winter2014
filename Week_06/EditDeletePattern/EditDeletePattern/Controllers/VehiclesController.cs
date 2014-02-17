using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// new...
using AutoMapper;

namespace EditDeletePattern.Controllers
{
    public class VehiclesController : Controller
    {
        // Create a reference to the 'manager' object
        private Manager m = new Manager();

        // ############################################################

        //
        // GET: /Vehicles/
        public ActionResult Index()
        {
            return View(m.GetAllVehicles());
        }

        //
        // GET: /Vehicles/Details/5
        public ActionResult Details(int id)
        {
            // Attempt to fetch the desired object
            var fetchedObject = m.GetVehicleById(id);

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
        // GET: /Vehicles/Create
        public ActionResult Create()
        {
            // Prepare the data for the view
            var addForm = new VehicleAddForm();

            // If necessary, provide initial values for the form
            addForm.ModelYear = DateTime.Now.Year;

            // Add the 'select' UI control items
            addForm.Manufacturers = new SelectList(m.GetAllManufacturersAsList(), "Id", "Name");

            return View(addForm);
        }

        //
        // POST: /Vehicles/Create
        [HttpPost]
        public ActionResult Create(VehicleAdd newItem)
        {
            if (ModelState.IsValid)
            {
                // Add the new object
                var addedItem = m.AddNewVehicle(newItem);

                if (addedItem == null)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    return RedirectToAction("details", new { Id = addedItem.Id });
                }
            }
            else
            {
                // Uh oh... problems with the incoming data...

                // Prepare the data for the view (again)
                var addForm = Mapper.Map<VehicleAddForm>(newItem);

                // Add the 'select' UI control items
                addForm.Manufacturers = new SelectList(m.GetAllManufacturersAsList(), "Id", "Name", newItem.ManufacturerId);

                return View(addForm);
            }
        }

        // ############################################################

        //
        // GET: /Vehicles/Edit/5
        public ActionResult Edit(int id)
        {
            // Prepare the object to be edited
            // We will be able to use the VehicleBase view model class
            // Then we'll selectively edit the scaffolded view to suit our needs

            // Attempt to get the object with the matching identifier
            VehicleBase fetchedObject = m.GetVehicleById(id);

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
        // POST: /Vehicles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VehicleBase newItem)
        {
            // Two tests are required...
            if (ModelState.IsValid & id == newItem.Id)
            {
                // Attempt to update the item
                VehicleBase editedItem = m.EditVehicle(newItem);

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
        // GET: /Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            // The type of the parameter above was changed to int?, a nullable int
            // This will suppress an error message

            // Attempt to fetch the object to be deleted
            // Notice that we must use a method on the nullable int
            VehicleBase itemToDelete = m.GetVehicleById(id.GetValueOrDefault());

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
        // POST: /Vehicles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            // Attempt to delete the item
            if (m.DeleteVehicleById(id))
            {
                // Succesful - item was deleted
                TempData["statusMessage"] = "This vehicle was deleted.";
            }
            else
            {
                // Request was not successful
                TempData["statusMessage"] = "Unable to delete this vehicle.";
            }
            return RedirectToAction("details", new { id = id });
        }

    }

}
