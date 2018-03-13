using System.Data.Entity.ModelConfiguration;
using TravelApp.DAL.Models;

namespace TravelApp.DAL.Configuration
{
    class CitiesWhichIWantToVisitConfiguration:EntityTypeConfiguration<CitiesWhichIWantToVisit>
    {
        public CitiesWhichIWantToVisitConfiguration()
        {
            ToTable("dbo.CitiesWhichIWantToVisits");

            HasKey(x => x.Id);
        }
    }
}
