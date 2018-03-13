using TravelApp.DAL;
using TravelApp.DAL.Context;

namespace TravelApp.BLL.Interfaces
{
    public interface ITravelsIdentityProvider
    {
        AuthorizationContext Context { get; }
        IUserManager GetUserManager(AuthorizationContext context);
    }
}
