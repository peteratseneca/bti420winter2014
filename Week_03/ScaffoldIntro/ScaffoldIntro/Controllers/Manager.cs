using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScaffoldIntro.Controllers
{
    public class Manager
    {
        // ############################################################
        // Initializiation

        // HTTP request context, which holds the Session object
        private HttpContext ctx = System.Web.HttpContext.Current;

        // Property for the Person collection
        private List<Person> _persons;
        public List<Person> Persons
        {
            // Custom getter
            get
            {
                if (ctx.Session["persons"] == null)
                {
                    //_persons = new List<Person>();
                    ctx.Session["persons"] = _persons;
                }
                else
                {
                    _persons = (List<Person>)ctx.Session["persons"];
                }
                return _persons;
                //return _persons.OrderBy(o => o.LastName).ToList();
            }
            set { _persons = value; }
        }

        public Manager()
        {
            this.Persons = new List<Person>();
        }

        // ############################################################

        public Person AddPerson(Person newPerson)
        {
            // Set the identifier value to the max-plus-one of the existing identifier values
            newPerson.Id = (this.Persons.Count > 0) ? this.Persons.Max(max => max.Id) + 1 : 1;
            // Add the object
            this.Persons.Add(newPerson);
            // Save
            ctx.Session["persons"] = this.Persons;
            return newPerson;
        }

        // ############################################################

        public Person EditPerson(Person editedPerson)
        {
            // Attempt to locate the existing object by using the passed-in identifier
            var existingPerson = this.Persons.SingleOrDefault(pid => pid.Id == editedPerson.Id);

            // If located...
            if (existingPerson != null)
            {
                // Get the object's index value in the collection
                int collectionIndex = this.Persons.IndexOf(existingPerson);
                // Replace the existing object with the new object
                this.Persons[collectionIndex] = editedPerson;
                // Save
                ctx.Session["persons"] = this.Persons;
                return editedPerson;
            }
            else
            {
                return null;
            }
        }

        // ############################################################

        public void RemovePerson(int id)
        {
            // Attempt to locate the existing object by using the passed-in identifier
            var existingPerson = this.Persons.SingleOrDefault(pid => pid.Id == id);
            // If located...
            if (existingPerson != null)
            {
                // Remove the object
                this.Persons.Remove(existingPerson);
                // Save
                ctx.Session["persons"] = this.Persons;
            }
        }

    }

}
