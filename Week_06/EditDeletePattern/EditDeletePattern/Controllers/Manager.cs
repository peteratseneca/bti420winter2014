using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using EditDeletePattern.Models;
using AutoMapper;

namespace EditDeletePattern.Controllers
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

            // Prepare and return the view model objects
            return Mapper.Map<IEnumerable<ManufacturerList>>(fetchedObjects);
        }

        public IEnumerable<ManufacturerBase> GetAllManufacturers()
        {
            // Fetch from the persistent store
            var fetchedObjects = ds.Manufacturers.OrderBy(man => man.Name);

            // Prepare and return the view model objects
            return Mapper.Map<IEnumerable<ManufacturerBase>>(fetchedObjects);
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
                return Mapper.Map<ManufacturerBase>(fetchedObject);
            }
        }

        // ############################################################
        // Add new

        public ManufacturerBase AddManufacturer(ManufacturerAdd newItem)
        {
            // Create a design model object

            Manufacturer man = Mapper.Map<Manufacturer>(newItem);

            // Add and save
            ds.Manufacturers.Add(man);
            ds.SaveChanges();

            // Prepare and return the object
            return Mapper.Map<ManufacturerBase>(man);
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

                // Prepare and return the object
                return Mapper.Map<ManufacturerBase>(fetchedObject);
            }
        }

        // ############################################################
        // Delete existing
        public bool DeleteManufacturerById(int id)
        {
            // Attempt to fetch the object
            var fetchedObject = ds.Manufacturers.Find(id);

            if (fetchedObject == null)
            {
                return false;
            }
            else
            {
                ds.Manufacturers.Remove(fetchedObject);
                return true;
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
            return Mapper.Map<IEnumerable<VehicleBase>>(fetchedObjects);
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
                // Prepare and return the result
                return Mapper.Map<VehicleBase>(fetchedObject);
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
                var addedItem = Mapper.Map<Vehicle>(newItem);
                addedItem.Manufacturer = m;

                // Add and save
                ds.Vehicles.Add(addedItem);
                ds.SaveChanges();

                // Prepare and return the result
                return Mapper.Map<VehicleBase>(addedItem);
            }
        }

        // ############################################################
        // Edit existing item

        public VehicleBase EditVehicle(VehicleBase newItem)
        {
            // Attempt to fetch the object with the matching identifier
            var fetchedObject = ds.Vehicles.Find(newItem.Id);

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

                // Prepare and return the object
                return Mapper.Map<VehicleBase>(fetchedObject);
            }
        }

        // ############################################################
        // Delete existing
        public bool DeleteVehicleById(int id)
        {
            // Attempt to fetch the object
            var fetchedObject = ds.Vehicles.Find(id);

            if (fetchedObject == null)
            {
                return false;
            }
            else
            {
                ds.Vehicles.Remove(fetchedObject);
                return true;
            }
        }

    }

}
