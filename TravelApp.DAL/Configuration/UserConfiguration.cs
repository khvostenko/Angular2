using System.Data.Entity.ModelConfiguration;
using TravelApp.DAL.Models;

namespace TravelApp.DAL.Configuration
{
    class UserConfiguration:EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("dbo.Users");
        }
    }
}
