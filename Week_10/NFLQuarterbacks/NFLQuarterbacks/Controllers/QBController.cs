using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFLQuarterbacks.Controllers
{
    public class QBController : Controller
    {
        private Manager m = new Manager();

        //
        // GET: /QB/
        public ActionResult Index()
        {
            return View(m.GetAllQB());
        }

        //
        // GET: /QB/Details/5
        public ActionResult Details(int id)
        {
            var fetchedObject = m.GetQBById(id);

            if (fetchedObject==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(fetchedObject);
            }
        }

        //
        // GET: /QB/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /QB/Create
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
        // GET: /QB/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /QB/Edit/5
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
        // GET: /QB/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /QB/Delete/5
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
