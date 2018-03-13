using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelApp.BLL.Interfaces;

namespace TravelApp.Controllers
{
    public class RolesController : ApiController
    {
        private readonly IAuthenticationService _authService;

        public RolesController(IAuthenticationService service)
        {
            _authService = service;
        }

        public IHttpActionResult Get()
        {
            var roles = _authService.GetAllRoles();
            return Json(roles);
        }
    }
}
