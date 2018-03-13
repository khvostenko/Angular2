using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelApp.BLL.DTO;
using TravelApp.BLL.Interfaces;
using TravelApp.DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;

namespace TravelApp.BLL.Identities
{
    public class AuthenticationService:IAuthenticationService
    {
        private readonly ITravelsIdentityProvider provider;

        public AuthenticationService()
        {
            this.provider = new TravelsIdentityProvider();
        }

        public async Task<IdentityResult> CreateAsync(User user)
        {
            using (var context = provider.Context)
            {
                IUserManager userManager = provider.GetUserManager(context);
                var result = await userManager.CreateAsync(user);
                return result;
            }
        }

        public async Task<IdentityResult> RegisterUser(UserRegisterDTO registerUserModel)
        {
            User usr = null;
            if (registerUserModel.RoleName == "User")
            {
                usr = new Person()
                {
                    UserName = registerUserModel.Email,
                    Email = registerUserModel.Email,
                    FullName = registerUserModel.Name,
                    PhoneNumber = registerUserModel.PhoneNumber
                };

            }
            else
            {
                usr = new Administrator()
                {
                    UserName = registerUserModel.Email,
                    Email = registerUserModel.Email,
                    FullName = registerUserModel.Name,
                    PhoneNumber = registerUserModel.PhoneNumber
                };
            }
           
            using (var context = provider.Context)
            {
                IUserManager manager = provider.GetUserManager(context);
                IdentityResult result = null;
                try
                {
                    result = await manager.CreateAsync(usr, registerUserModel.Password);
                }
                catch(Exception ex)
                {
                    throw ex;
                }

                if(result.Succeeded)
                {
                    result = await manager.AddToRoleAsync(usr.Id, registerUserModel.RoleName);
                }
                return result;
            }
        }

        public async Task<User> FindUser(string userName, string password)
        {
            using (var context = provider.Context)
            {
                IUserManager manager = provider.GetUserManager(context);
                User user = await manager.FindAsync(userName, password);
                return user;
            }
        }

        public async Task<IdentityResult> ChangePassword(long userID, string currentPassword, string newPassword)
        {
            using (var context = provider.Context)
            {
                IUserManager manager = provider.GetUserManager(context);
                var result = await manager.ChangePasswordAsync(userID, currentPassword, newPassword);
                return result;
            }
        }

        public async Task<ClaimsIdentity> CreateIdentity(User user, string authenticationType)
        {
            using (var context = provider.Context)
            {
                IUserManager manager = provider.GetUserManager(context);
                var userIdentity = await manager.CreateIdentityAsync(user, authenticationType);
                return userIdentity;
            }
        }

        public async Task<User> FindAsync(UserLoginInfo login)
        {
            using (var context = provider.Context)
            {
                IUserManager manager = provider.GetUserManager(context);
                var userIdentity = await manager.FindAsync(login);
                return userIdentity;
            }
        }

        public string GenerateAccessTokenResponse(User user, OAuthAuthorizationServerOptions options)
        {
            ClaimsIdentity identity = CreateExternalIdentity(user, options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            var props = new AuthenticationProperties()
            {
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddDays(14)
            };

            var ticket = new AuthenticationTicket(identity, props);
            var accessToken = options.AccessTokenFormat.Protect(ticket);
            return accessToken;
        }

        public async Task<bool> HasRegistered(UserLoginInfo login)
        {
            var user = await FindAsync(login);
            return user != null;
        }

        public async Task<string> GetAllRolesJson(long userID)
        {
            using (var context = provider.Context)
            {
                var manager = provider.GetUserManager(context);
                var listRoles = await manager.GetRolesAsync(userID);
                var rolesString = JsonConvert.SerializeObject(listRoles);
                return rolesString;
            }
        }

        public  ICollection<RoleDTO> GetAllRoles()
        {
            using (var context = provider.Context)
            {
                return context.Roles
                    .Select(r => new RoleDTO()
                    {
                        Id = r.Id,
                        Name = r.Name
                    }).ToList();
            }
        }

        private ClaimsIdentity CreateExternalIdentity(User user, string authenticationType)
        {
            using (var context = provider.Context)
            {
                var manager = provider.GetUserManager(context);
                return manager.CreateExternalIdentity(user, authenticationType);
            }
        }
    }
}
