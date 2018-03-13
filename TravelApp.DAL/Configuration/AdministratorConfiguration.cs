using System.Data.Entity.ModelConfiguration;
using TravelApp.DAL.Models;

namespace TravelApp.DAL.Configuration
{
    class AdministratorConfiguration:EntityTypeConfiguration<Administrator>
    {
        public AdministratorConfiguration()
        {
            ToTable("dbo.Administrators");
        }
    }
}
