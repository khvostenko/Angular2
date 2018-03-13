using System.Collections.Generic;
using System.Linq;
using TravelApp.BLL.DTO;
using TravelApp.BLL.Interfaces;
using TravelApp.DAL.Interface;
using TravelApp.DAL.Models;

namespace TravelApp.BLL.Services
{
    public class CitiesWhichIWantToVisitService : ICitiesWhichIWantToVisitService
    {
        private readonly IUnitOfWork _uow;

        public CitiesWhichIWantToVisitService(IUnitOfWorkFactory uowFactory)
        {
            _uow = uowFactory.Create();
        }

        public bool AddCitiesWhichIWantToVisit(CitiesWhichIWantToVisitDTO citiesWhichIWantToVisit)
        {
            using (_uow)
            {
                var tempCitiesWhichIWantToVisit = new CitiesWhichIWantToVisit();
                tempCitiesWhichIWantToVisit.CityId = citiesWhichIWantToVisit.CityId;
                _uow.CitiesWhichIWantToVisitRepository.Insert(tempCitiesWhichIWantToVisit);
                _uow.Save();
            }
            return true;
        }

        public bool DeleteCitiesWhichIWantToVisit(long id)
        {
            using (_uow)
            {
                var tempCitiesWhichIWantToVisit = _uow.CitiesWhichIWantToVisitRepository.GetById(id);
                _uow.CitiesWhichIWantToVisitRepository.Delete(tempCitiesWhichIWantToVisit);
                _uow.Save();
            }
            return true;
        }

        public ICollection<CitiesWhichIWantToVisitDTO> GetAllCitiesWhichIWantToVisit()
        {
            using (_uow)
            {
                return _uow.CitiesWhichIWantToVisitRepository.Query().Select(d => new CitiesWhichIWantToVisitDTO()
                {
                    Id = d.Id,
                    CityId = d.CityId
                }).ToList();
            }
        }

        public ICollection<CityWhichIWantToVisitFullDTO> GetAllCitiesWhichIWantToVisitByUser(long userID)
        {
            using (_uow)
            {
                return _uow.CitiesWhichIWantToVisitRepository.Query().Select(x => new CityWhichIWantToVisitFullDTO()
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

        public CitiesWhichIWantToVisitDTO GetCitiesWhichIWantToVisitById(long id)
        {
            using (_uow)
            {
                return _uow.CitiesWhichIWantToVisitRepository.Query().Select(d => new CitiesWhichIWantToVisitDTO()
                {
                    Id = d.Id,
                    CityId = d.CityId
                }).FirstOrDefault(d => d.Id == id);
            }
        }

        public CityWhichIWantToVisitFullDTO GetFullCityWhichIWantToVisit(long id)
        {
            using (_uow)
            {
                var city = _uow.CitiesWhichIWantToVisitRepository.GetById(id);
                if (city != null)
                {
                    var cityFullDto = new CityWhichIWantToVisitFullDTO()
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
                    return new CityWhichIWantToVisitFullDTO();
                }
            }
        }

        public CityWhichIWantToVisitFullDTO GetFullCityWhichIWantToVisitByName(string cityName)
        {
            using (_uow)
            {
                var city = _uow.CitiesWhichIWantToVisitRepository.Query().Where(d => d.City.Name == cityName).SingleOrDefault();
                if (city != null)
                {
                    var cityFullDto = new CityWhichIWantToVisitFullDTO()
                    {
                        Id = city.Id,
                        CityId = city.CityId,
                        PersonId = city.Persons.Select(x => new PersonDTO()
                        {
                            Id = x.Id,
                            Name = x.FullName,
                            Email = x.Email,
                            PhoneNumber = x.PhoneNumber
                        }).ToList()
                    };
                    return cityFullDto;
                }
                else return new CityWhichIWantToVisitFullDTO();
            }
        }

        public bool UpdateCitiesWhichIWantToVisit(CitiesWhichIWantToVisitDTO citiesWhichIWantToVisit)
        {
            using (_uow)
            {
                var tempCitiesWhichIVantToVisit = _uow.CitiesWhichIWantToVisitRepository.GetById(citiesWhichIWantToVisit.Id);
                tempCitiesWhichIVantToVisit.CityId = citiesWhichIWantToVisit.CityId;
                _uow.CitiesWhichIWantToVisitRepository.Update(tempCitiesWhichIVantToVisit);
                _uow.Save();
            }
            return true;
        }
    }
}
