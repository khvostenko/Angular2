using TravelApp.DAL.Context;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TravelApp.DAL.Identity
{
    public class CustomRoleStore:RoleStore<CustomRole,long, CustomUserRole>
    {
        public CustomRoleStore(AuthorizationContext context) : base(context)
        {

        }
    }
}
