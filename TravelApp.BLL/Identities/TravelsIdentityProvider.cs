using TravelApp.BLL.Interfaces;
using TravelApp.DAL.Context;
using TravelApp.DAL.Identity;

namespace TravelApp.BLL.Identities
{
    public class TravelsIdentityProvider:ITravelsIdentityProvider
    {
        public AuthorizationContext Context => new AuthorizationContext();

        public IUserManager GetUserManager(AuthorizationContext context)
        {
            CustomUserStore store = new CustomUserStore(context);
            IUserManager manager = new CustomUserManager(store);

            return manager;
        }
    }
}
