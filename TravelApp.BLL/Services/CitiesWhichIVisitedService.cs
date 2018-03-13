using System.Collections.Generic;
using System.Linq;
using TravelApp.BLL.DTO;
using TravelApp.BLL.Interfaces;
using TravelApp.DAL.Interface;
using TravelApp.DAL.Models;

namespace TravelApp.BLL.Services
{
    public class CitiesWhichIVisitedService : ICitiesWhichIVisitedService
    {
        private readonly IUnitOfWork _uow;

        public CitiesWhichIVisitedService(IUnitOfWorkFactory uowFactory)
        {
            _uow = uowFactory.Create();
        }

        public bool AddCitiesWhichIVisited(CitiesWhichIVisitedDTO citiesWhichIVisited)
        {
            using (_uow)
            {
                CitiesWhichIVisited tempCitiesWhichIVisited = new CitiesWhichIVisited();
                tempCitiesWhichIVisited.CityId = citiesWhichIVisited.CityId;
                tempCitiesWhichIVisited.Id = citiesWhichIVisited.Id;
                _uow.CitiesWhichIVisitedRepository.Insert(tempCitiesWhichIVisited);
                _uow.Save();
            }
            return true;
        }

        public bool DeleteCitiesWhichIVisited(long id)
        {
            using (_uow)
            {
                var tempCitiesWhichIVisited = _uow.CitiesWhichIVisitedRepository.GetById(id);
                _uow.CitiesWhichIVisitedRepository.Delete(tempCitiesWhichIVisited);
                _uow.Save();
            }
            return true;
        }

        public ICollection<CitiesWhichIVisitedDTO> GetAllCitiesWhichIVisited()
        {
            using (_uow)
            {
                return _uow.CitiesWhichIVisitedRepository.Query().Select(d => new CitiesWhichIVisitedDTO()
                {
                    Id = d.Id,
                    CityId = d.CityId
                }).ToList();
            }
        }

        public CitiesWhichIVisitedDTO GetCitiesWhichIVisitedById(long id)
        {
            using (_uow)
            {
                return _uow.CitiesWhichIVisitedRepository.Query().Select(d => new CitiesWhichIVisitedDTO()
                {
                    Id = d.Id,
                    CityId = d.CityId
                    
                }).FirstOrDefault(d => d.Id == id);
            }
        }

        public ICollection<CityWhichIVisitedFullDTO> GetFullAllCitiesWhichIVisitedByUser(long userID)
        {
            using (_uow)
            {
                return _uow.CitiesWhichIVisitedRepository.Query().Select(x => new CityWhichIVisitedFullDTO()
                {
                    Id = x.Id,
                    CityId = x.CityId,
                    PersonId = x.Persons.Select(d => new PersonDTO()
                    {
                        Id = userID,
                        Email = d.Email,
                        Name = d.FullName,
                        PhoneNumber = d.PhoneNumber
                    }).ToList()
                }).ToList();
            }
        }

        public CityWhichIVisitedFullDTO GetFullCityWhichIVisited(long id)
        {
            using (_uow)
            {
                var city = _uow.CitiesWhichIVisitedRepository.GetById(id);
                if (city != null)
                {
                    var cityFullDto = new CityWhichIVisitedFullDTO()
                    {
                        Id = city.Id,
                        CityId = city.CityId,
                        PersonId = city.Persons.Select(x => new PersonDTO()
                        {
                            Id = x.Id,
                            Email = x.Email,
                            Name = x.FullName,
                            PhoneNumber = x.PhoneNumber
                        }).ToList()
                    };
                    return cityFullDto;
                }
                else
                {
                    return new CityWhichIVisitedFullDTO();
                }
            }
        }

        public CityWhichIVisitedFullDTO GetFullCityWhichIVisitedByName(string cityName)
        {
            using (_uow)
            {
                var city = _uow.CitiesWhichIVisitedRepository.Query().Where(d => d.City.Name == cityName).SingleOrDefault();
                if (city != null)
                {
                    var cityFullDto = new CityWhichIVisitedFullDTO()
                    {
                        Id = city.Id,
                        CityId = city.CityId,
                        PersonId = city.Persons.Select(x => new PersonDTO()
                        {
                            Id = x.Id,
                            Name = x.FullName,
                            Email = x.Email,
                            PhoneNumber = x.PhoneNumber,
                            Password=x.PasswordHash,
                            ConfirmPassword=x.PasswordHash
                        }).ToList()
                    };
                    return cityFullDto;
                }
                else return new CityWhichIVisitedFullDTO();
            }
        }

        public bool UpdateCitiesWhichIVisited(CitiesWhichIVisitedDTO citiesWhichIVisited)
        {
            using (_uow)
            {
                var tempCitiesWhichIVisited = _uow.CitiesWhichIVisitedRepository.GetById(citiesWhichIVisited.Id);
                tempCitiesWhichIVisited.CityId = citiesWhichIVisited.CityId;
                _uow.CitiesWhichIVisitedRepository.Update(tempCitiesWhichIVisited);
                _uow.Save();
            }
            return true;
        }

        
    }
}
