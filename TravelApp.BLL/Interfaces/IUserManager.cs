using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelApp.DAL.Models;
using Microsoft.AspNet.Identity;

namespace TravelApp.BLL.Interfaces
{
    public interface IUserManager
    {
        Task<IdentityResult> CreateAsync(User user);
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<IdentityResult> AddToRoleAsync(long userID, params string[] roles);
        Task<User> FindAsync(string userName, string password);
        Task<User> FindAsync(UserLoginInfo login);
        Task<IdentityResult> AddLoginAsync(long userID, UserLoginInfo login);
        Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationType);
        ClaimsIdentity CreateExternalIdentity(User user, string authenticationType);
        Task<User> FindByEmailAsync(string email);
        Task<IList<string>> GetRolesAsync(long userID);
        Task<IdentityResult> ChangePasswordAsync(long userID, string currentPassword, string newPassword);
    }
}
