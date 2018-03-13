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
    public class CitiesWhichIVisitedController : ApiController
    {
        private readonly ICitiesWhichIVisitedService _cityService;

        public CitiesWhichIVisitedController(ICitiesWhichIVisitedService service)
        {
            _cityService = service;
        }

        public ICollection<CitiesWhichIVisitedDTO> Get()
        {
            return _cityService.GetAllCitiesWhichIVisited();
        }

        [HttpGet]
        [Route("api/citieswhichivisitedbyuser/{id}")]
        public ICollection<CityWhichIVisitedFullDTO> GetAllCitiesWhichIVisitedByUser(long userId)
        {
            return _cityService.GetFullAllCitiesWhichIVisitedByUser(userId);
        }
        [Route("api/citieswhichivisitedbyid/{id}")]
        public CitiesWhichIVisitedDTO Get(int id)
        {
            return _cityService.GetCitiesWhichIVisitedById(id);
        }

        [HttpGet]
        [Route("api/citieswhichivisitedfullbyid/{id}")]
        public CityWhichIVisitedFullDTO GetFullCityWhichIVisitedById(long id)
        {
            return _cityService.GetFullCityWhichIVisited(id);
        }

        [HttpPut]
        public void Put([FromBody]CitiesWhichIVisitedDTO cities)
        {
            _cityService.UpdateCitiesWhichIVisited(cities);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            _cityService.DeleteCitiesWhichIVisited(id);
            return true;
        }

        [HttpPost]
        public bool Post([FromBody]CitiesWhichIVisitedDTO cities)
        {
            _cityService.AddCitiesWhichIVisited(cities);
            return true;
        }
    }
}
