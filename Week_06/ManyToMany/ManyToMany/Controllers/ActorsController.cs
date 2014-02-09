using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManyToMany.Controllers
{
    public class ActorsController : Controller
    {
        // Reference to the manager object
        Manager m = new Manager();

        //
        // GET: /Actors/
        public ActionResult Index()
        {
            return View(m.GetAllActorsWithMovies());
        }
	}
}
