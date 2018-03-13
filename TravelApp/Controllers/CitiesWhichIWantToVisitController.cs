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
    public class CitiesWhichIWantToVisitController : ApiController
    {
        private readonly ICitiesWhichIWantToVisitService _cityService;

        public CitiesWhichIWantToVisitController(ICitiesWhichIWantToVisitService service)
        {
            _cityService = service;
        }
        [Route("api/allcitieswhichiwanttovisit")]
        public ICollection<CitiesWhichIWantToVisitDTO> Get()
        {
            return _cityService.GetAllCitiesWhichIWantToVisit();
        }

        [HttpGet]
        public ICollection<CityWhichIWantToVisitFullDTO> GetAllCitiesWhichIVantToVisitByUser(long userID)
        {
            return _cityService.GetAllCitiesWhichIWantToVisitByUser(userID);
        }

        [HttpGet]
        [Route("api/fullcitieswhichiwanttovisitbyid/{id}")]
        public CityWhichIWantToVisitFullDTO GetCity(long id)
        {
            return _cityService.GetFullCityWhichIWantToVisit(id);
        }
        [Route("api/citieswhichiwanttovisitid/{id}")]
        public CitiesWhichIWantToVisitDTO Get(int id)
        {
            return _cityService.GetCitiesWhichIWantToVisitById(id);
        }

        [HttpPut]
        public void Put([FromBody]CitiesWhichIWantToVisitDTO city)
        {
            _cityService.UpdateCitiesWhichIWantToVisit(city);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            _cityService.DeleteCitiesWhichIWantToVisit(id);
            return true;
        }

        [HttpPost]
        public bool Post([FromBody]CitiesWhichIWantToVisitDTO city)
        {
            _cityService.AddCitiesWhichIWantToVisit(city);
            return true;
        }
    }
}
