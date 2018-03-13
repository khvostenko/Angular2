using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using TravelApp.Providers;
using TravelApp.Results;
using TravelApp.BLL.Interfaces;
using TravelApp.BLL.DTO;

namespace TravelApp.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly IAuthenticationService _authService;

        public AccountController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        public async Task<IHttpActionResult> Register(UserRegisterDTO userModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IdentityResult result = await _authService.RegisterUser(userModel);
            if(!result.Succeeded)
            {
                return GetErrorResult(result);
            }
            return Ok();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result.Errors != null)
            {
                foreach(string error in result.Errors)
                {
                    ModelState.AddModelError("error", error);
                }
            }
            if(ModelState.IsValid)
            {
                return BadRequest();
            }
            return BadRequest(ModelState);
        }
    }
}
