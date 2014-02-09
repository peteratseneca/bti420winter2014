using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.Data.Entity;

namespace ManyToMany.Models
{
    //public class StoreInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    public class StoreInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            // Create some initial data

            // Actors...

            var jen = new Actor() { GivenNames = "Jennifer", LastName = "Lawrence", BirthDate = new DateTime(1990, 8, 15) };
            context.Actors.Add(jen);

            var stan = new Actor() { GivenNames = "Stanley", LastName = "Tucci", BirthDate = new DateTime(1960, 1, 11) };
            context.Actors.Add(stan);

            var zach = new Actor() { GivenNames = "Zachary", LastName = "Quinto", BirthDate = new DateTime(1977, 6, 2) };
            context.Actors.Add(zach);

            // Movies...

            var hunger = new Movie() { Name = "The Hunger Games", DateReleased = new DateTime(2012, 3, 23), Studio = "Color Force", Director = "Gary Ross" };
            context.Movies.Add(hunger);

            var silver = new Movie() { Name = "Silver Linings Playbook", DateReleased = new DateTime(2012, 11, 16), Studio = "The Weinstein Company", Director = "David O. Russell" };
            context.Movies.Add(silver);

            var margin = new Movie() { Name = "Margin Call", DateReleased = new DateTime(2011, 10, 21), Studio = "Before The Door Pictures", Director = "J.C. Chandor" };
            context.Movies.Add(margin);

            var star = new Movie() { Name = "Star Trek Into Darkness", DateReleased = new DateTime(2013, 5, 16), Studio = "Bad Robot Pictures", Director = "J.J. Abrams" };
            context.Movies.Add(star);

            var hustle = new Movie() { Name = "American Hustle", DateReleased = new DateTime(2013, 12, 13), Studio = "Atlas Entertainment", Director = "David O. Russell" };
            context.Movies.Add(hustle);

            context.SaveChanges();

            // Set the associations...

            hunger.Actors.Add(jen);
            hunger.Actors.Add(stan);

            silver.Actors.Add(jen);

            margin.Actors.Add(stan);
            margin.Actors.Add(zach);

            star.Actors.Add(zach);

            hustle.Actors.Add(jen);

            context.SaveChanges();

        }
    }
}
