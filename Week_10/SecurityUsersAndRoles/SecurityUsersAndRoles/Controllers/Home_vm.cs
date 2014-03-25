using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel;

namespace SecurityUsersAndRoles.Controllers
{
    public class ApplicationUserBase
    {
        public ApplicationUserBase()
        {
            this.RolesForUser = new List<string>();
        }

        public string Id { get; set; }
        [DisplayName("Given name(s)")]
        public string GivenNames { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
        [DisplayName("Email address")]
        public string Email { get; set; }
        [DisplayName("User name")]
        public string UserName { get; set; }

        [DisplayName("Roles for user")]
        public ICollection<string> RolesForUser { get; set; }
    }

}
