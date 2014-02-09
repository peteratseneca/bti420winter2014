using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;

namespace ManyToMany.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Actors = new List<Actor>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public DateTime DateReleased { get; set; }
        // In a better model, the following would be 
        // a nav property to a "Director" class
        [Required]
        [StringLength(100)]
        public string Director { get; set; }
        [Required]
        [StringLength(100)]
        public string Studio { get; set; }

        public ICollection<Actor> Actors { get; set; }
    }

    public class Actor
    {
        public Actor()
        {
            this.Movies = new List<Movie>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string GivenNames { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
