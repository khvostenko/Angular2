namespace TravelApp.DAL.Models
{
    public class CityVisitedPerson
    {
        public long? PersonId { get; set; }
        public long? CitiyWhichIVisitedId { get; set; }

        public virtual CitiesWhichIVisited City { get; set; }
        public virtual Person Person { get; set; }
    }
}
