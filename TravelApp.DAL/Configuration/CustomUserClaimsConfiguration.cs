using System.Data.Entity.ModelConfiguration;
using TravelApp.DAL.Identity;

namespace TravelApp.DAL.Configuration
{
    internal class CustomUserClaimsConfiguration:EntityTypeConfiguration<CustomUserClaim>
    {
        public CustomUserClaimsConfiguration()
        {
            ToTable("dbo.UserClaims");
            HasKey(x => x.Id);
        }
    }
}
