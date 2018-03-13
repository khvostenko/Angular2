using System.Data.Entity.ModelConfiguration;
using TravelApp.DAL.Models;

namespace TravelApp.DAL.Configuration
{
    class CityConfiguration:EntityTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            ToTable("dbo.Cities");

            HasKey(x => x.Id);

            Property(x => x.Rating).IsRequired();
            Property(x => x.Country).IsRequired();
            Property(x => x.Name).IsRequired();

            //HasMany(x => x.CitiesWhichIVisiteds)
            //    .WithOptional(x => x.City)
            //    .HasForeignKey(x => x.CityId);

            //HasMany(x => x.CitiesWhichIWantToVisits)
            //    .WithOptional(x => x.City)
            //    .HasForeignKey(x => x.CityId);

            HasMany(x => x.Comments)
                .WithOptional(x => x.City)
                .HasForeignKey(x => x.CityId);

            HasMany(x => x.Photos)
                .WithOptional(x => x.City)
                .HasForeignKey(x => x.CityId);
        }
    }
}
