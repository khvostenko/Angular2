using System.Data.Entity.ModelConfiguration;
using TravelApp.DAL.Identity;

namespace TravelApp.DAL.Configuration
{
    internal class CustomUserLoginsConfiguration:EntityTypeConfiguration<CustomUserLogin>
    {
        public CustomUserLoginsConfiguration()
        {
            ToTable("dbo.UserLogins");
            HasKey(x => new { x.ProviderKey, x.LoginProvider, x.UserId });
        }
    }
}
