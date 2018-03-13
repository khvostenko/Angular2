using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelApp.BLL.DTO;
using TravelApp.BLL.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace TravelApp.Controllers
{
    public class PersonsController : ApiController
    {
        private readonly IPersonService _personService;
        private readonly IAuthenticationService _authService;

        public PersonsController(IPersonService personService, IAuthenticationService authenticationService)
        {
            _personService = personService;
            _authService = authenticationService;
        }

        public ICollection<PersonDTO> Get()
        {
            return _personService.GetAllPersons();
        }

        [HttpGet]
        [Route("api/persons/search/{personName}")]
        public ICollection<PersonDTO> Search(string personName)
        {
            return _personService.GetAllPersonsByName(personName);
        }

        public PersonDTO Get(int id)
        {
            return _personService.GetPersonById(id);
        }

        [HttpGet]
        [Route("api/persons/full-info/{id}")]
        public PersonFullDTO GetFullPerson(long id)
        {
            return _personService.GetPersonFullDTO(id);
        }

        [HttpPut]
        public void Put([FromBody]PersonDTO person)
        {
            _personService.UpdatePerson(person);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            _personService.DeletePerson(id);
            return true;
        }

        [HttpPost]
        public async Task<bool> Post([FromBody]PersonDTO person)
        {
            var newPerson = new UserRegisterDTO()
            {
                Password = person.Password,
                ConfirmPassword = person.ConfirmPassword,
                RoleName = "User",
                Email = person.Email,
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                userId = person.Id
            };
            IdentityResult result = await _authService.RegisterUser(newPerson);

            if (!result.Succeeded)
            {
                return false;
            }
            else
                return true;
        }

        [HttpGet]
        [Route("api/persons/register")]
        public async Task<IHttpActionResult> Register([FromBody]UserRegisterDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newPerson = new UserRegisterDTO()
            {
                Password = user.Password,
                ConfirmPassword = user.ConfirmPassword,
                RoleName = "User",
                Email = user.Email,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                userId = user.userId
            };

            IdentityResult result = await _authService.RegisterUser(newPerson);

            if (!result.Succeeded)
            {
                return BadRequest(ModelState);
            }
            else
                return Ok();

        }
    }
}
