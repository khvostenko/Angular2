using System.Collections.Generic;
using System.Linq;
using TravelApp.BLL.DTO;
using TravelApp.BLL.Interfaces;
using TravelApp.DAL.Interface;
using TravelApp.DAL.Models;

namespace TravelApp.BLL.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _uow;

        public CityService(IUnitOfWorkFactory uowFactory)
        {
            _uow = uowFactory.Create();
        }

        public bool AddCity(CityDTO city)
        {
            using (_uow)
            {
                var tempCity = new City();
                tempCity.Country = city.Country;
                tempCity.Name = city.Name;
                tempCity.Rating = city.Rating;
                _uow.CityRepository.Insert(tempCity);
                _uow.Save();
            }
            return true;
        }

        public bool DeleteCity(long id)
        {
            using (_uow)
            {
                var tempCity = _uow.CityRepository.GetById(id);
                _uow.CityRepository.Delete(tempCity);
                _uow.Save();
            }
            return true;
        }

        public ICollection<CityDTO> GetAllCities()
        {
            using (_uow)
            {
                return _uow.CityRepository.Query().Select(d => new CityDTO()
                {
                    Country = d.Country,
                    Id = d.Id,
                    Rating = d.Rating
                }).ToList();
            }
        }

        public CityDTO GetCityById(long id)
        {
            using (_uow)
            {
                return _uow.CityRepository.Query().Select(d => new CityDTO()
                {
                    Id = d.Id,
                    Country = d.Country,
                    Rating = d.Rating
                }).FirstOrDefault(d => d.Id == id);


            }
        }

        public bool UpdateCity(CityDTO city)
        {
            using (_uow)
            {
                var tempCity = _uow.CityRepository.GetById(city.Id);
                tempCity.Country = city.Country;
                tempCity.Name = city.Name;
                tempCity.Rating = city.Rating;
                _uow.CityRepository.Update(tempCity);
                _uow.Save();
            }
            return true;
        }

        public ICollection<CityFullDTO> GetFullAllCitiesByUser(long userID)
        {
            using (_uow)
            {
                return _uow.CityRepository.Query().Select(d => new CityFullDTO()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Country = d.Country,
                    Rating = d.Rating,
                    photos = d.Photos.Select(p => new PhotoDTO()
                    {
                        Id = p.Id,
                        CityId = p.CityId,
                        Date = p.Date,
                        Image = p.Image,
                        PersonId = p.PersonId
                    }).ToList(),
                    comments = d.Comments.Select(c => new CommentDTO()
                    {
                        Id = c.Id,
                        Text = c.Text,
                        CityId = c.CityId,
                        Date = c.Date,
                        PersonId = c.PersonId
                    }).ToList()
                }).Where(d => d.Id == userID).ToList();
            }
        }

        public CityFullDTO GetFullCityById(long id)
        {
            using (_uow)
            {
                var city = _uow.CityRepository.GetById(id);
                if (city != null)
                {
                    var cityFullDto = new CityFullDTO()
                    {
                        Id = city.Id,
                        Name = city.Name,
                        Country = city.Country,
                        Rating = city.Rating,
                        comments = city.Comments.Select(c => new CommentDTO()
                        {
                            Id = c.Id,
                            Text = c.Text,
                            Date = c.Date,
                            CityId = c.CityId,
                            PersonId = c.PersonId
                        }).ToList(),
                        photos = city.Photos.Select(p => new PhotoDTO()
                        {
                            Id = p.Id,
                            Date = p.Date,
                            Image = p.Image,
                            CityId = p.CityId,
                            PersonId = p.PersonId
                        }).ToList()
                    };
                    return cityFullDto;
                }
                else return new CityFullDTO();
            }
        }

        public CityDTO GetCityByNameAndCountry(string cityName, string cityCountry)
        {
            using (_uow)
            {
                var city = _uow.CityRepository.Query().Where(d => d.Name == cityName && d.Country == cityCountry).SingleOrDefault();
                if (city != null)
                {
                    var cityDto = new CityDTO()
                    {
                        Id = city.Id,
                        Name = city.Name,
                        Country = city.Country,
                        Rating = city.Rating
                    };
                    return cityDto;
                }
                else return new CityDTO();
            }
        }
    }
}
