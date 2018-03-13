using TravelApp.BLL.DTO;
using System.Collections.Generic;

namespace TravelApp.BLL.Interfaces
{
    public interface ICitiesWhichIVisitedService
    {
        ICollection<CitiesWhichIVisitedDTO> GetAllCitiesWhichIVisited();
        ICollection<CityWhichIVisitedFullDTO> GetFullAllCitiesWhichIVisitedByUser(long userID);

        CityWhichIVisitedFullDTO GetFullCityWhichIVisited(long id);
        CityWhichIVisitedFullDTO GetFullCityWhichIVisitedByName(string cityName);

        CitiesWhichIVisitedDTO GetCitiesWhichIVisitedById(long id);
        bool UpdateCitiesWhichIVisited(CitiesWhichIVisitedDTO citiesWhichIVisited);
        bool DeleteCitiesWhichIVisited(long id);
        bool AddCitiesWhichIVisited(CitiesWhichIVisitedDTO citiesWhichIVisited);
    }
}
