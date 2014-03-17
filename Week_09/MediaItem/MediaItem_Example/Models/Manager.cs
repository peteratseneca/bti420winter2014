using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediaItem_Example.Controllers;
using AutoMapper;

namespace MediaItem_Example.Models
{
    public class Manager
    {
        DataContext dc = new DataContext();

        public IEnumerable<VehicleBase> AllVehicles()
        {
            var fetchedObjects = dc.Vehicles.AsEnumerable();
            var Vehicles = new List<VehicleBase>();
            foreach (var item in fetchedObjects)
            {
                Vehicles.Add(Mapper.Map<Controllers.VehicleBase>(item));
            }
            return Vehicles;
        }

        public VehicleBase GetVehicleById(int id)
        {
            var v = dc.Vehicles.Find(id);
            
            if(v == null)
            {
                return null;
            }
            else
            {
                return (Mapper.Map<Controllers.VehicleBase>(v));
            }
        }

        public VehicleBase AddVehicle(VehicleBase v)
        {
            dc.Vehicles.Add(Mapper.Map<Models.Vehicle>(v));
            dc.SaveChanges();
            return v;
        }
    }
}