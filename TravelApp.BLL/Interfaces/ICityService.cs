using TravelApp.BLL.DTO;
using System.Collections.Generic;


namespace TravelApp.BLL.Interfaces
{
    public interface ICityService
    {
        ICollection<CityDTO> GetAllCities();
        ICollection<CityFullDTO> GetFullAllCitiesByUser(long userID);
        CityFullDTO GetFullCityById(long id);
        CityDTO GetCityById(long id);
        CityDTO GetCityByNameAndCountry(string cityName, string cityCountry);
        bool UpdateCity(CityDTO city);
        bool AddCity(CityDTO city);
        bool DeleteCity(long id);
    }
}
