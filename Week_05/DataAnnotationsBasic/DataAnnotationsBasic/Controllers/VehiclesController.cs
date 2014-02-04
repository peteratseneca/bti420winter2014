using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAnnotationsBasic.Controllers
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
                var addForm = new VehicleAddForm();

                // Add the 'select' UI control items
                addForm.Manufacturers = new SelectList(m.GetAllManufacturersAsList(), "Id", "Name", newItem.ManufacturerId);

                // Copy over the data that didn't validate
                addForm.Model = newItem.Model;
                addForm.Trim = newItem.Trim;
                addForm.ModelYear = newItem.ModelYear;
                addForm.MSRP = newItem.MSRP;

                return View(addForm);
            }
        }

        // ############################################################

        //
        // GET: /Vehicles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Vehicles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // ############################################################

        //
        // GET: /Vehicles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Vehicles/Delete/5
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

    }

}
