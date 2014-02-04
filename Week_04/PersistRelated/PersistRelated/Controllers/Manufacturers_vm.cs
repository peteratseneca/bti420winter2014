using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersistRelated.Controllers
{
    // To be used in a user interface list/selection control
    public class ManufacturerList
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // Supports the 'add new' task
    // Can be sent to the HTML Form, and received from the HTML Form
    public class ManufacturerAdd
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int YearStarted { get; set; }
    }

    // Supports common 'get' tasks
    // Inherits from the class above
    public class ManufacturerBase : ManufacturerAdd
    {
        public int Id { get; set; }
    }

}
