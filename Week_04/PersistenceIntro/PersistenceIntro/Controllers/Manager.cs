using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using PersistenceIntro.Models;

namespace PersistenceIntro.Controllers
{
    // This manages/coordinates/mediates/marshals data operations

    public class Manager
    {
        // Create a reference to the data context
        private DataContext dc = new DataContext();

        // Manufacturer

        public IEnumerable<ManufacturerBase> GetAllManufacturers()
        {
            // Fetch from the persistent store
            var fetchedObjects = dc.Manufacturers.OrderBy(man => man.Name);

            // Prepare the view model objects

            // Create a collection
            var manufacturers = new List<ManufacturerBase>();

            // Go through the fetch results
            foreach (var item in fetchedObjects)
            {
                var man = new ManufacturerBase();
                man.Id = item.Id;
                man.Name = item.Name;
                man.Country = item.Country;
                man.YearStarted = item.YearStarted;
                manufacturers.Add(man);
            }

            return manufacturers;
        }

    }

}
