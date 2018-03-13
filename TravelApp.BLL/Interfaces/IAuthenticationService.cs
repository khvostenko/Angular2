using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelApp.BLL.DTO;
using TravelApp.DAL.Models;
using Microsoft.AspNet.Identity;

namespace TravelApp.BLL.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> CreateAsync(User user);
        Task<IdentityResult> RegisterUser(UserRegisterDTO registerUserModel);
        Task<IdentityResult> ChangePassword(long userID, string currentPassword, string newPassword);
        Task<User> FindUser(string userName, string password);
        Task<ClaimsIdentity> CreateIdentity(User user, string authenticationType);
        Task<User> FindAsync(UserLoginInfo login);
        Task<bool> HasRegistered(UserLoginInfo login);
        Task<string> GetAllRolesJson(long userID);
        ICollection<RoleDTO> GetAllRoles();
    }
}
