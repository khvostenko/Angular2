using System.Data.Entity.ModelConfiguration;
using TravelApp.DAL.Models;

namespace TravelApp.DAL.Configuration
{
    class CitiesWhichIVisitedConfiguration:EntityTypeConfiguration<CitiesWhichIVisited>
    {
        public CitiesWhichIVisitedConfiguration()
        {
            ToTable("dbo.CitiesWhichIVisiteds");

            HasKey(x => x.Id);

        }
    }
}
