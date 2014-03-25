using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityUsersAndRoles.Controllers
{
    public class FacultyController : Controller
    {
        private Manager m = new Manager();

        //
        // GET: /Faculty/
        public ActionResult Index()
        {
            // Get all

            return View(m.GetAllFaculty());
        }

        //
        // GET: /Faculty/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Faculty/Create
        [Authorize(Roles = "Faculty")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Faculty/Create
        [Authorize(Roles="Faculty")]
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
        // GET: /Faculty/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Faculty/Edit/5
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
        // GET: /Faculty/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Faculty/Delete/5
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
