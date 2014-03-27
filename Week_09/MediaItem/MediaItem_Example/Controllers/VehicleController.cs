using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediaItem_Example.Models;
using AutoMapper;

namespace MediaItem_Example.Controllers
{
    public class VehicleController : Controller
    {
        Manager m = new Manager();
        //
        // GET: /Vehicle/
        public ActionResult Index()
        {
            return View(m.AllVehicles());
        }

        //
        // GET: /Vehicle/Details/5
        public ActionResult Details(int id)
        {
            var fetchedObject = m.GetVehicleById(id);

            if(fetchedObject == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(fetchedObject);
            }
        }

        //
        // GET: /Vehicle/Create
        public ActionResult Create()
        {
            var AddForm = new AddVehicleForm();
            return View(AddForm);
        }

        //
        // POST: /Vehicle/Create
        [HttpPost]
        public ActionResult Create(AddVehicle VehicleToAdd)
        {
            // Create a vehicle object
            var v = Mapper.Map<VehicleBase>(VehicleToAdd);

            // Get the uploaded file, and assign it to the vehicle object's properties
            byte[] PhotoBytes = new byte[VehicleToAdd.PhotoUpload.ContentLength];
            VehicleToAdd.PhotoUpload.InputStream.Read(PhotoBytes, 0, VehicleToAdd.PhotoUpload.ContentLength);
            v.Photo = PhotoBytes;
            v.PhotoType = VehicleToAdd.PhotoUpload.ContentType;

            m.AddVehicle(v);

            return RedirectToAction("index");
        }

        //
        // GET: /Vehicle/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Vehicle/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Vehicle");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Vehicle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Vehicle/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Vehicle");
            }
            catch
            {
                return View();
            }
        }
    }
}
