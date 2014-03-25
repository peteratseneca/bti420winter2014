using Microsoft.AspNet.Identity.EntityFramework;
// new...
using System;
using System.Data.Entity;

// This source code file was created by the Visual Studio 2013 project template
// We will NOT create our own 'DbContext' class
// Instead, we will use the "ApplicationDbContext" class that you see below
// It inherits from IdentityDbContext, which inherits from DbContext

namespace SecurityUsersAndRoles.Models
{
    // You can add profile data for users by adding more properties 
    // to the ApplicationUser class; for more info, visit 
    // http://go.microsoft.com/fwlink/?LinkID=317594 

    // If you add more properties, you must also do the following:
    // 1. Enable Code First Migrations
    // 2. Update the RegisterViewModel class
    // 3. Update Views/Account/Register.cshtml
    // 4. Update the Register (HttpPost) action in the Account controller

    public class ApplicationUser : IdentityUser
    {
        public string GivenNames { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<Faculty> Faculty { get; set; }
    }
}
