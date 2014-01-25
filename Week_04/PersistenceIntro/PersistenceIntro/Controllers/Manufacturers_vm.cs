using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersistenceIntro.Controllers
{
    // Supports the 'add new' task
    public class ManufacturerAdd
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int YearStarted { get; set; }
    }

    // Supports common 'get' tasks
    public class ManufacturerBase : ManufacturerAdd
    {
        public int Id { get; set; }
    }

}
