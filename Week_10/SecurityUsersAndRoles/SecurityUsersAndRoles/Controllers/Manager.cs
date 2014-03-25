using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using SecurityUsersAndRoles.Models;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SecurityUsersAndRoles.Controllers
{
    public class Manager
    {
        // Context
        private ApplicationDbContext ds = new ApplicationDbContext();

        // Get all
        public IEnumerable<FacultyBase> GetAllFaculty()
        {
            var fetchedObjects = ds.Faculty.OrderBy(nm => nm.Name);

            return AutoMapper.Mapper.Map<IEnumerable<FacultyBase>>(fetchedObjects);
        }

        // Get user info for a specific user name
        public ApplicationUserBase GetUserInfo(string userName)
        {
            // Create a user manager object
            var userManager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ds));

            // Attempt to fetch the user object
            var userObject = userManager.FindByName(userName);

            if (userObject==null)
            {
                return null;
            }
            else
            {
                // Prepare a view model object
                var appUser = Mapper.Map<ApplicationUserBase>(userObject);
                // Add the role names
                foreach (var role in userObject.Roles)
                {
                    appUser.RolesForUser.Add(role.Role.Name);
                }

                return appUser;
            }
        }

    }
}
