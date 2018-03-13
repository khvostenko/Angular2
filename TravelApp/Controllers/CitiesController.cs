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
    public class CitiesController : ApiController
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        
        public ICollection<CityDTO> Get()
        {
            return _cityService.GetAllCities();
        }

        [Route("api/fullcitiesbyuser/{id}")]
        public ICollection<CityFullDTO> Get(long userId)
        {
            return _cityService.GetFullAllCitiesByUser(userId);
        }

        [HttpGet]
        [Route("api/citybycountry/{cityName}/{cityCountry}")]
        public CityDTO GetCityByNameAndCountry(string cityName, string cityCountry)
        {
            return _cityService.GetCityByNameAndCountry(cityName, cityCountry);
        }

        [HttpGet]
        [Route("api/citybyid/{id}")]
        public CityDTO GetCity(long id)
        {
            return _cityService.GetCityById(id);
        }

        [HttpGet]
        [Route("api/fullcitybyid/{id}")]
        public CityFullDTO GetFullCity(long id)
        {
            return _cityService.GetFullCityById(id);
        }

        [HttpPut]
        public void Put([FromBody]CityDTO city)
        {
            _cityService.UpdateCity(city);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            _cityService.DeleteCity(id);
            return true;
        }

        [HttpPost]
        public bool Post([FromBody]CityDTO city)
        {
            _cityService.AddCity(city);
            return true;
        }
    }
}
