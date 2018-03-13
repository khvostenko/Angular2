using System.Collections.Generic;

namespace TravelApp.DAL.Models
{
    public class CitiesWhichIWantToVisit
    {
        public long Id { get; set; }

        public long? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Person> Persons { get; set; }

        public CitiesWhichIWantToVisit()
        {
            Persons = new HashSet<Person>();
        }
    }
}
