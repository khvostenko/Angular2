using TravelApp.BLL.Identities;
using TravelApp.BLL.Interfaces;
using TravelApp.DAL.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TravelApp.Providers
{
    public class TravelAppOAuthProvider: OAuthAuthorizationServerProvider
    {
        private readonly IAuthenticationService authService;

        public TravelAppOAuthProvider()
        {
            this.authService = new AuthenticationService();
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => context.Validated());
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            User user = await authService.FindUser(context.UserName, context.Password);
            if (user == null) 
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            ClaimsIdentity oAuthIdentity = await authService.CreateIdentity(user, OAuthDefaults.AuthenticationType);
            oAuthIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            var rolesString = await authService.GetAllRolesJson(user.Id);
            AuthenticationProperties properties = CreateProperties(user.UserName, rolesString, user.Id, user.LockoutEnabled);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);

            context.Validated(ticket);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach(KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        private AuthenticationProperties CreateProperties(string userName, string roles, long id, bool isBlocked)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName },
                { "roles", roles },
                { "id", id.ToString() },
                { "isBlocked", isBlocked.ToString() }
            };
            return new AuthenticationProperties(data);
        }
    }
}