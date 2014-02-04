using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using PersistIntro.Models;

namespace PersistIntro.Controllers
{
    // This class manages/coordinates/mediates/marshals data operations

    public class Manager
    {
        // Create a reference to the data context
        private DataContext ds = new DataContext();

        // Manufacturer

        // Get all
        public IEnumerable<ManufacturerBase> GetAllManufacturers()
        {
            // Fetch from the persistent store
            var fetchedObjects = ds.Manufacturers.OrderBy(man => man.Name);

            // Prepare the view model objects...

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

        // Get one; notice the name of the method
        public ManufacturerBase GetManufacturerById(int id)
        {
            // Fetch the object using its identifier
            // A DbSet collection supports the spiffy Find() method
            // Way easier syntax than SingleOrDefault(), 
            // because it doesn't need a lambda expression
            var fetchedObject = ds.Manufacturers.Find(id);

            if (fetchedObject == null)
            {
                // Return null to the caller (who will also test the result)
                return null;
            }
            else
            {
                // Create and deliver a view model object
                var man = new ManufacturerBase();
                man.Id = fetchedObject.Id;
                man.Name = fetchedObject.Name;
                man.Country = fetchedObject.Country;
                man.YearStarted = fetchedObject.YearStarted;

                return man;
            }
        }

        // Add new
        public ManufacturerBase AddManufacturer(ManufacturerAdd newItem)
        {
            // Create a design model object
            Manufacturer man = new Manufacturer();
            man.Name = newItem.Name;
            man.Country = newItem.Country;
            man.YearStarted = newItem.YearStarted;
            
            // Add and save
            ds.Manufacturers.Add(man);
            ds.SaveChanges();

            // Prepare the object to be returned
            ManufacturerBase addedItem = new ManufacturerBase();
            addedItem.Id = man.Id;
            addedItem.Name = man.Name;
            addedItem.Country = man.Country;
            addedItem.YearStarted = man.YearStarted;

            return addedItem;
        }

        // Edit existing
        public ManufacturerBase EditManufacturer(ManufacturerBase newItem)
        {
            // Attempt to fetch the object with the matching identifier
            var fetchedObject = ds.Manufacturers.Find(newItem.Id);

            if (fetchedObject == null)
            {
                // Return null to the caller (who will also test the result)
                return null;
            }
            else
            {
                // Update the object with the incoming values
                // Before doing this, we may have to perform 
                // business-rule validations 
                ds.Entry(fetchedObject).CurrentValues.SetValues(newItem);
                ds.SaveChanges();

                // Prepare the object to be returned
                var editedItem = new ManufacturerBase();
                editedItem.Id = fetchedObject.Id;
                editedItem.Name = fetchedObject.Name;
                editedItem.Country = fetchedObject.Country;
                editedItem.YearStarted = fetchedObject.YearStarted;

                return editedItem;
            }
        }

    }

}
