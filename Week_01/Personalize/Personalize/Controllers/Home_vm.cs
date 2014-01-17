using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personalize.Controllers
{
    public class Person
    {
        // To quickly add "automatic properties", 
        // type "prop" and press the Tab key twice 
        // Then use Tab / Shift+Tab to highlight the replaceable text,
        // and enter your desired type name and property name

        // Property names begin with an uppercase letter
        // Multipart property names use camel-casing

        public int Id { get; set; }
        public string GivenNames { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public string FullName()
        {
            return string.Format("{0} {1}", this.GivenNames, this.LastName);
        }
    }

}
