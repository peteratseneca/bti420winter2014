using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScaffoldIntro.Controllers
{
    public class PersonsController : Controller
    {
        // Reference to a 'manager' object
        private Manager m = new Manager();

        // ############################################################

        //
        // GET: /Persons/
        public ActionResult Index()
        {
            // Fetch the collection of Person objects
            return View(m.Persons.OrderBy(o => o.LastName).ToList());
        }

        //
        // GET: /Persons/Details/5
        public ActionResult Details(int id)
        {
            // Fetch the Person object with the matching identifier
            var person = m.Persons.SingleOrDefault(pid => pid.Id == id);
            // Return the details view, or return to the Index view
            if (person == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(person);
            }
        }

        // ############################################################

        //
        // GET: /Persons/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Persons/Create
        [HttpPost]
        public ActionResult Create(Person newPerson)
        {
            if (ModelState.IsValid)
            {
                // Attempt to add the new Person object
                m.AddPerson(newPerson);
                return RedirectToAction("Index");
            }
            return View();
        }

        // ############################################################

        //
        // GET: /Persons/Edit/5
        public ActionResult Edit(int id)
        {
            // Attempt to edit the Person object with the matching identifier
            var person = m.Persons.SingleOrDefault(pid => pid.Id == id);
            // Return the editor view, or return to the Index view
            if (person == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(person);
            }
        }

        //
        // POST: /Persons/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Person updatedperson)
        {
            if (ModelState.IsValid)
            {
                // Attempt to update the Person object
                m.EditPerson(updatedperson);
                return RedirectToAction("Index");
            }
            return View();
        }

        // ############################################################

        //
        // GET: /Persons/Delete/5
        public ActionResult Delete(int id)
        {
            m.RemovePerson(id);
            return RedirectToAction("Index");
        }

    }

}
