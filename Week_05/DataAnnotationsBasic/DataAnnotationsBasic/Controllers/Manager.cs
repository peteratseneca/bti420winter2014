using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using DataAnnotationsBasic.Models;

namespace DataAnnotationsBasic.Controllers
{
    // This class manages/coordinates/mediates/marshals data operations

    public class Manager
    {
        // Create a reference to the data context
        private DataContext ds = new DataContext();

        // Manufacturer

        // ############################################################
        // Get all as list, get all, get one

        public IEnumerable<ManufacturerList> GetAllManufacturersAsList()
        {
            // Fetch from the persistent store
            var fetchedObjects = ds.Manufacturers.OrderBy(man => man.Name);

            // Prepare the view model objects...

            // Create a collection
            var manufacturers = new List<ManufacturerList>();

            // Go through the fetch results
            foreach (var item in fetchedObjects)
            {
                var man = new ManufacturerList();
                man.Id = item.Id;
                man.Name = item.Name;
                manufacturers.Add(man);
            }

            // Return the result
            return manufacturers;
        }

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

            // Return the result
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

        // ############################################################
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

            // Return the result
            return addedItem;
        }

        // ############################################################
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

                // Return the result
                return editedItem;
            }
        }

        // Vehicle

        // ############################################################
        // Get all, get one

        public IEnumerable<VehicleBase> GetAllVehicles()
        {
            // Fetch from the data store
            var fetchedObjects = ds.Vehicles.Include("Manufacturer").OrderBy(m => m.Model);

            // Prepare the return result
            var vehicles = new List<VehicleBase>();

            foreach (var item in fetchedObjects)
            {
                var v = new VehicleBase()
                {
                    Id = item.Id,
                    Model = item.Model,
                    Trim = item.Trim,
                    ModelYear = item.ModelYear,
                    MSRP = item.MSRP,
                    ManufacturerId = item.Manufacturer.Id,
                    ManufacturerName = item.Manufacturer.Name
                };
                vehicles.Add(v);
            }

            // Return the result
            return vehicles;
        }

        public VehicleBase GetVehicleById(int id)
        {
            // Attempt to fetch from the data store
            var fetchedObject = ds.Vehicles.Include("Manufacturer").SingleOrDefault(i => i.Id == id);

            if (fetchedObject == null)
            {
                return null;
            }
            else
            {
                // Prepare the return result
                var v = new VehicleBase()
                {
                    Id = fetchedObject.Id,
                    Model = fetchedObject.Model,
                    Trim = fetchedObject.Trim,
                    ModelYear = fetchedObject.ModelYear,
                    MSRP = fetchedObject.MSRP,
                    ManufacturerId = fetchedObject.Manufacturer.Id,
                    ManufacturerName = fetchedObject.Manufacturer.Name
                };

                // Return the result
                return v;
            }
        }

        // ############################################################
        // Add new

        public VehicleBase AddNewVehicle(VehicleAdd newItem)
        {
            // Attempt to fetch the associated object
            var m = ds.Manufacturers.Find(newItem.ManufacturerId);

            if (m == null)
            {
                return null;
            }
            else
            {
                // Associated object is valid, so continue

                // Create a new design model object
                var addedItem = new Vehicle()
                {
                    Model = newItem.Model,
                    Trim = newItem.Trim,
                    ModelYear = newItem.ModelYear,
                    MSRP = newItem.MSRP,
                    Manufacturer = m
                };

                // Add and save
                ds.Vehicles.Add(addedItem);
                ds.SaveChanges();

                // Prepare the return object
                var v = new VehicleBase()
                {
                    Id = addedItem.Id,
                    Model = addedItem.Model,
                    Trim = addedItem.Trim,
                    ModelYear = addedItem.ModelYear,
                    MSRP = addedItem.MSRP,
                    ManufacturerId = m.Id,
                    ManufacturerName = m.Name
                };

                // Return the result
                return v;
            }
        }

        // ############################################################
        // Edit existing item



    }

}
