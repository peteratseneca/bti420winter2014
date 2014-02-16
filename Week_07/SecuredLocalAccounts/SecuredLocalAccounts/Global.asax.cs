using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
// new...
using AutoMapper;

namespace SecuredLocalAccounts
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Data store initializer
            //System.Data.Entity.Database.SetInitializer(new Models.StoreInitializer());

            // AutoMapper configuration

            // Manufacturer

            // From design model class to view model class
            Mapper.CreateMap<Models.Manufacturer, Controllers.ManufacturerList>();
            Mapper.CreateMap<Models.Manufacturer, Controllers.ManufacturerBase>();

            // From view model class to design model class
            Mapper.CreateMap<Controllers.ManufacturerAdd, Models.Manufacturer>();

            // Vehicle

            // From design model class to view model class
            Mapper.CreateMap<Models.Vehicle, Controllers.VehicleList>();
            Mapper.CreateMap<Models.Vehicle, Controllers.VehicleBase>();
            Mapper.CreateMap<Models.Vehicle, Controllers.VehicleBaseWithManufacturer>();

            // From view model class to design model class
            Mapper.CreateMap<Controllers.VehicleAdd, Models.Vehicle>();

            // Other maps
            Mapper.CreateMap<Controllers.VehicleAdd, Controllers.VehicleAddForm>();
        
        }
    }
}
