using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SecurityUsersAndRoles.Models
{
    public class StoreInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Users.Count() == 0)
            {
                // Configure the startup users and roles

                // Create a user manager object
                var userManager =
                    new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                // Create a role manager object
                var roleManager =
                    new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                // Create roles
                foreach (var role in new List<string>() { "Administrator", "Coordinator", "Faculty", "Student" })
                {
                    // This StoreInitializer class inherits from "CreateDatabaseIfNotExists<TContext>"
                    // Therefore, it is not necessary to check or test whether the role exists already
                    // Just go ahead and create the roles, using this foreach loop, or four separate statements
                    roleManager.Create(new IdentityRole(role));
                }

                // Create users

                var admin = new ApplicationUser()
                {
                    GivenNames = "App",
                    LastName = "Administrator",
                    Email = "admin@example.com",
                    UserName = "admin"
                };
                userManager.Create(admin, "password!");
                userManager.AddToRole(admin.Id, "Administrator");

                var ian = new ApplicationUser()
                {
                    GivenNames = "Ian",
                    LastName = "Tipson",
                    Email = "ian@example.com",
                    UserName = "iantipson"
                };
                userManager.Create(ian, "password!");
                userManager.AddToRole(ian.Id, "Faculty");

                // Add objects to the Faculty collection

                var peter = new Faculty() { Id = 1, Name = "Peter", EmailAddress = "peter@example.com" };
                context.Faculty.Add(peter);

                var elliott = new Faculty() { Id = 2, Name = "Elliott", EmailAddress = "elliott@example.com" };
                context.Faculty.Add(elliott);

                context.SaveChanges();
            }
        }
    }

}
