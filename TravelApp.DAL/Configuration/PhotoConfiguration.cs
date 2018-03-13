using System.Data.Entity.ModelConfiguration;
using TravelApp.DAL.Models;

namespace TravelApp.DAL.Configuration
{
    class PhotoConfiguration:EntityTypeConfiguration<Photo>
    {
        public PhotoConfiguration()
        {
            ToTable("dbo.Photos");
        }
    }
}
