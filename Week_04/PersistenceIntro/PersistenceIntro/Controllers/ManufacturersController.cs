using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersistenceIntro.Controllers
{
    public class ManufacturersController : Controller
    {
        // Create a reference to the 'manager'
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
            return View();
        }

        //
        // GET: /Manufacturers/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Manufacturers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Manufacturers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Manufacturers/Edit/5
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

        //
        // GET: /Manufacturers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

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
    }
}
