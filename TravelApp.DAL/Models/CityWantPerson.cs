namespace TravelApp.DAL.Models
{
    public class CityWantPerson
    {
        public long? CityWhichIWantToVisitId { get; set; }
        public long? PersonId { get; set; }

        public virtual CitiesWhichIWantToVisit City { get; set; }
        public virtual Person Person { get; set; }
    }
}
