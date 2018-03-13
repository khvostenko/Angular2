using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelApp.BLL.DTO;
using TravelApp.BLL.Interfaces;

namespace TravelApp.Controllers
{
    public class AdministratorsController : ApiController
    {
        private readonly IAdministratorService _adminService;

        public AdministratorsController(IAdministratorService adminService)
        {
            _adminService = adminService;
        }

        public ICollection<AdministratorDTO> Get()
        {
            return _adminService.GetAllAdministrator();
        }

        public AdministratorDTO Get(int id)
        {
            return _adminService.GetAdministratorById(id);
        }

        [HttpPut]
        public void Put([FromBody]AdministratorDTO administrator)
        {
            _adminService.UpdateAdministrator(administrator);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            _adminService.DeleteAdministrator(id);
            return true;
        }

        [HttpPost]
        public bool Post([FromBody]AdministratorDTO administrator)
        {
            _adminService.AddAdministrator(administrator);
            return true;
        }
    }
}
