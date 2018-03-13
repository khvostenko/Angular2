using System.Data.Entity.ModelConfiguration;
using TravelApp.DAL.Models;

namespace TravelApp.DAL.Configuration
{
    class PersonConfiguration:EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            ToTable("dbo.Persons");

            HasKey(x => x.Id);

            //HasMany(x => x.CitiesWhichIVisiteds)
            //    .WithOptional(x => x.Person)
            //    .HasForeignKey(x => x.PersonId);

            //HasMany(x => x.CitiesWhichIWantToVisits)
            //    .WithOptional(x => x.Person)
            //    .HasForeignKey(x => x.PersonId);

            HasMany(x => x.Photos)
                .WithOptional(x => x.Person)
                .HasForeignKey(x => x.PersonId);

            HasMany(x => x.Comments)
                .WithOptional(x => x.Person)
                .HasForeignKey(x => x.PersonId);
        }
    }
}
