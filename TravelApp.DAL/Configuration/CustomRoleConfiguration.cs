using System.Data.Entity.ModelConfiguration;
using TravelApp.DAL.Identity;

namespace TravelApp.DAL.Configuration
{
    internal class CustomRoleConfiguration:EntityTypeConfiguration<CustomRole>
    {
        public CustomRoleConfiguration()
        {
            ToTable("dbo.Roles");
            HasKey(x => x.Id);
        }
    }
}
