using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using ManyToMany.Models;

namespace ManyToMany.Controllers
{
    public class Manager
    {
        DataContext ds = new DataContext();

        // ############################################################
        // Movies

        public IEnumerable<MovieBaseWithActors> GetAllMoviesWithActors()
        {
            // Fetch from the persistent store
            var fetchedObjects = 
                ds.Movies
                .Include("Actors")
                .OrderBy(mn => mn.Name);

            // Prepare and return the view model objects
            return Mapper.Map<IEnumerable<MovieBaseWithActors>>(fetchedObjects);
        }

        // ############################################################
        // Actors

        public IEnumerable<ActorBaseWithMovies> GetAllActorsWithMovies()
        {
            // Fetch from the persistent store
            var fetchedObjects = 
                ds.Actors
                .Include("Movies")
                .OrderBy(ln => ln.LastName)
                .ThenBy(gn => gn.GivenNames);

            // Prepare and return the view model objects
            return Mapper.Map<IEnumerable<ActorBaseWithMovies>>(fetchedObjects);
        }
    
    }

}
