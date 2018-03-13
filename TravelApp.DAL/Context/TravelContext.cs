using System.Collections.Generic;
using System.Data.Entity;
using TravelApp.DAL.Configuration;
using TravelApp.DAL.Identity;
using TravelApp.DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TravelApp.DAL.Context
{
    public class TravelContext:DbContext
    {
        public TravelContext() : base("name=TravelApp")
        {
            Database.SetInitializer<AuthorizationContext>(new CreateDatabaseIfNotExists<AuthorizationContext>());
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<CitiesWhichIVisited> CitiesWhichIVisiteds { get; set; }
        public virtual DbSet<CitiesWhichIWantToVisit> CitiesWhichIWantToVisits { get; set; }
        public virtual DbSet<CityVisitedPerson> CityVisitedPersons { get; set; }
        public virtual DbSet<CityWantPerson> CityWantPersons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CustomRoleConfiguration());
            modelBuilder.Configurations.Add(new CustomUserClaimsConfiguration());
            modelBuilder.Configurations.Add(new CustomUserLoginsConfiguration());
            modelBuilder.Configurations.Add(new CustomUserRolesConfiguration());

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
        }
    }
}
