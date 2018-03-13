using TravelApp.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TravelApp.DAL.Models
{
    public abstract class User: IdentityUser<long, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public string FullName { get; set; }
    }
}
