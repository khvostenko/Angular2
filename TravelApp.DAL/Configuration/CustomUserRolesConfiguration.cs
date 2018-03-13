using System.Data.Entity.ModelConfiguration;
using TravelApp.DAL.Identity;

namespace TravelApp.DAL.Configuration
{
    internal class CustomUserRolesConfiguration:EntityTypeConfiguration<CustomUserRole>
    {
        public CustomUserRolesConfiguration()
        {
            ToTable("dbo.UsersRoles");
            HasKey(x => new { x.UserId, x.RoleId });
        }
    }
}
