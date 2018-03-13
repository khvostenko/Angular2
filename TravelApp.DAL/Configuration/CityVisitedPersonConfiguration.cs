using System.Data.Entity.ModelConfiguration;
using TravelApp.DAL.Models;


namespace TravelApp.DAL.Configuration
{
    public class CityVisitedPersonConfiguration:EntityTypeConfiguration<CityVisitedPerson>
    {
        public CityVisitedPersonConfiguration()
        {
            ToTable("dbo.CityVisitedPersons");

            HasKey(x => new { x.CitiyWhichIVisitedId, x.PersonId });
        }
    }
}
