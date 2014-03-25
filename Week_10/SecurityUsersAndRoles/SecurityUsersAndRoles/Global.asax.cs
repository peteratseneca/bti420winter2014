using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
// new...
using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SecurityUsersAndRoles
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            System.Data.Entity.Database.SetInitializer(new Models.StoreInitializer());

            // AutoMapper maps

            Mapper.CreateMap<Models.ApplicationUser, Controllers.ApplicationUserBase>();

            Mapper.CreateMap<Models.Faculty, Controllers.FacultyBase>();
            Mapper.CreateMap<Controllers.FacultyBase, Models.Faculty>();
        }
    }
}
