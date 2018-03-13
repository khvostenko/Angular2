using System.Collections.Generic;

namespace TravelApp.DAL.Models
{
    public class Person:User
    {
        public virtual ICollection<CitiesWhichIWantToVisit> CitiesWhichIWantToVisits { get; set; }
        public virtual ICollection<CitiesWhichIVisited> CitiesWhichIVisiteds { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public Person()
        {
            CitiesWhichIWantToVisits = new HashSet<CitiesWhichIWantToVisit>();
            CitiesWhichIVisiteds = new HashSet<CitiesWhichIVisited>();
            Photos = new HashSet<Photo>();
            Comments = new HashSet<Comment>();
        }
    }
}
