using System.Data.Entity.ModelConfiguration;
using TravelApp.DAL.Models;

namespace TravelApp.DAL.Configuration
{
    public class CityWantPersonConfiguration:EntityTypeConfiguration<CityWantPerson>
    {
        public CityWantPersonConfiguration()
        {
            ToTable("dbo.CityWantPersons");

            HasKey(x => new { x.CityWhichIWantToVisitId, x.PersonId });
        }
    }
}
