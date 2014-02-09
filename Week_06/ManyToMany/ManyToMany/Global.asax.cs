using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
// new...
using AutoMapper;

namespace ManyToMany
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //System.Data.Entity.Database.SetInitializer(new Models.StoreInitializer());

            // Movies
            Mapper.CreateMap<Models.Movie, Controllers.MovieBase>();
            Mapper.CreateMap<Models.Movie, Controllers.MovieBaseWithActors>();

            // Actors
            Mapper.CreateMap<Models.Actor, Controllers.ActorBase>();
            Mapper.CreateMap<Models.Actor, Controllers.ActorBaseWithMovies>();

        }
    }
}
