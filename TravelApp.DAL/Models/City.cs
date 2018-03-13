using System.Collections.Generic;

namespace TravelApp.DAL.Models
{
    public class City
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public double Rating { get; set; }

        public virtual CitiesWhichIVisited CitiesWhichIVisiteds{ get; set; }
        public virtual CitiesWhichIWantToVisit CitiesWhichIWantToVisits { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public City()
        {
            Photos = new HashSet<Photo>();
            Comments = new HashSet<Comment>();
        }
    }
}
