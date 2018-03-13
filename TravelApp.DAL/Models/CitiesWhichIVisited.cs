using System;
using System.Collections.Generic;

namespace TravelApp.DAL.Models
{
    public class CitiesWhichIVisited
    {
        public long Id { get; set; }

        public long? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Person> Persons { get; set; }

        public CitiesWhichIVisited()
        {
            Persons = new HashSet<Person>();
        }
    }
}
