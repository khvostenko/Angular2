using TravelApp.DAL.Context;
using Microsoft.AspNet.Identity.EntityFramework;
using TravelApp.DAL.Models;

namespace TravelApp.DAL.Identity
{
    public class CustomUserStore : UserStore<User, CustomRole, long, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(AuthorizationContext context) : base(context)
        {

        }

    }
}
