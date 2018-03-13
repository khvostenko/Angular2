using System.Security.Claims;
using System.Threading.Tasks;
using TravelApp.BLL.Interfaces;
using TravelApp.DAL.Identity;
using TravelApp.DAL.Models;
using Microsoft.AspNet.Identity;

namespace TravelApp.BLL.Identities
{
    public class CustomUserManager : UserManager<User, long>, IUserManager
    {
        public CustomUserManager(CustomUserStore store)
            : base(store)
        {
            UserValidator = new UserValidator<User, long>(this)
            {
                AllowOnlyAlphanumericUserNames = false
            };
        }

        public ClaimsIdentity CreateExternalIdentity(User user, string authenticationType)
        {
            return this.CreateIdentity(user, authenticationType);
        }

        public Task<IdentityResult> ChangePasswordAsync(long userId, string currentPassword, string newPassword)
        {
            return base.ChangePasswordAsync(userId, currentPassword, newPassword);
        }

        public Task<IdentityResult> AddToRoleAsync(long userId, params string[] roles)
        {
            return base.AddToRolesAsync(userId, roles);
        }
    }
}