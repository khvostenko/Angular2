using System.Collections.Generic;
using System.Linq;
using TravelApp.BLL.DTO;
using TravelApp.BLL.Interfaces;
using TravelApp.DAL.Interface;
using TravelApp.DAL.Models;

namespace TravelApp.BLL.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAuthenticationService _authService;

        public PersonService(IUnitOfWorkFactory uowFactory, IAuthenticationService authService)
        {
            _uow = uowFactory.Create();
            _authService = authService;
        }

        public bool AddPerson(PersonDTO person)
        {
            var tempPerson = new UserRegisterDTO()
            {
                Password = person.Password,
                ConfirmPassword = person.Password,
                RoleName = "User",
                Email = person.Email,
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                userId = person.Id
            };
            var result = _authService.RegisterUser(tempPerson).Result;
            return result.Succeeded;
        }

        public bool DeletePerson(int id)
        {
            using (_uow)
            {
                var tempPerson = _uow.PersonRepository.GetById(id);
                _uow.PersonRepository.Delete(tempPerson);
                _uow.Save();
            }
            return true;
        }

        public ICollection<PersonDTO> GetAllPersons()
        {
            using (_uow)
            {
                return _uow.PersonRepository.Query().Select(d => new PersonDTO()
                {
                    Id = d.Id,
                    Email = d.Email,
                    Name = d.FullName,
                    PhoneNumber = d.PhoneNumber
                }).ToList();
            }
        }

        public ICollection<PersonDTO> GetAllPersonsByName(string personName)
        {
            using (_uow)
            {
                return _uow.PersonRepository.Query().Select(d => new PersonDTO()
                {
                    Id = d.Id,
                    Email = d.Email,
                    Name = d.FullName,
                    PhoneNumber = d.PhoneNumber
                }).Where(d => d.Name.Contains(personName)).ToList();
            }
        }

        public PersonDTO GetPersonById(int id)
        {
            using (_uow)
            {
                return _uow.PersonRepository.Query().Select(d => new PersonDTO()
                {
                    Id = d.Id,
                    Email = d.Email,
                    Name = d.FullName,
                    PhoneNumber = d.PhoneNumber
                }).FirstOrDefault(d => d.Id == id);
            }
        }

        public PersonFullDTO GetPersonFullDTO(long id)
        {
            using (_uow)
            {
                var person = _uow.PersonRepository.GetById(id);
                if (person != null)
                {
                    var personFullDto = new PersonFullDTO()
                    {
                        Id = person.Id,
                        Email = person.Email,
                        Name = person.FullName,
                        PhoneNumber = person.PhoneNumber,

                        citiesVisited = person.CitiesWhichIVisiteds.Select(cw => new CitiesWhichIVisitedDTO()
                        {
                            Id = cw.Id,
                            CityId = cw.CityId
                        }).ToList(),

                        citiesWant = person.CitiesWhichIWantToVisits.Select(cv => new CitiesWhichIWantToVisitDTO()
                        {
                            Id = cv.Id,
                            CityId = cv.CityId
                        }).ToList(),
                        commnets = person.Comments.Select(c => new CommentDTO()
                        {
                            Id = c.Id,
                            CityId = c.CityId,
                            Date = c.Date,
                            PersonId = c.PersonId,
                            Text = c.Text
                        }).ToList(),
                        photos = person.Photos.Select(p => new PhotoDTO()
                        {
                            Id = p.Id,
                            CityId = p.CityId,
                            Date = p.Date,
                            Image = p.Image,
                            PersonId = p.PersonId
                        }).ToList()
                    };
                    return personFullDto;
                }
                else return new PersonFullDTO();
            }
        }

        public bool UpdatePerson(PersonDTO person)
        {
            using (_uow)
            {
                var tempPerson = _uow.PersonRepository.GetById(person.Id);
                tempPerson.FullName = person.Name;
                tempPerson.Email = person.Email;
                tempPerson.UserName = person.Email;
                tempPerson.PhoneNumber = person.PhoneNumber;
                _uow.PersonRepository.Update(tempPerson);
                _uow.Save();
            }
            return true;
        }
    }
}
