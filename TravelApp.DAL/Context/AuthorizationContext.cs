using System.Collections.Generic;
using System.Data.Entity;
using TravelApp.DAL.Configuration;
using TravelApp.DAL.Identity;
using TravelApp.DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TravelApp.DAL.Context
{
    public class AuthorizationContext: IdentityDbContext<User, CustomRole, long, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public AuthorizationContext() : base("name=TravelApp")
        {
            Database.SetInitializer<AuthorizationContext>(new CreateDatabaseIfNotExists<AuthorizationContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Configurations.Add(new AdministratorConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
            //modelBuilder.Configurations.Add(new CityConfiguration());
            //modelBuilder.Configurations.Add(new CitiesWhichIVisitedConfiguration());
            //modelBuilder.Configurations.Add(new CitiesWhichIWantToVisitConfiguration());
            modelBuilder.Configurations.Add(new PhotoConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new CityVisitedPersonConfiguration());
            modelBuilder.Configurations.Add(new CityWantPersonConfiguration());

            modelBuilder.Entity<City>()
                .HasRequired(s => s.CitiesWhichIVisiteds)
                .WithRequiredPrincipal(ad => ad.City);
            modelBuilder.Entity<City>()
                .HasRequired(s => s.CitiesWhichIWantToVisits)
                .WithRequiredPrincipal(ad => ad.City);


            ConfigureIdentityTables(modelBuilder);


        }

        private void ConfigureIdentityTables(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomRole>().ToTable("dbo.Roles");
            modelBuilder.Entity<CustomUserRole>().ToTable("dbo.UsersRoles");
            modelBuilder.Entity<CustomUserLogin>().ToTable("dbo.UserLogins");
            modelBuilder.Entity<CustomUserClaim>().ToTable("dbo.UserClaims");

        }

    }
}
