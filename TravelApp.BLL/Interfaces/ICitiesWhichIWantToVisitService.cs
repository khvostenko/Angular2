using TravelApp.BLL.DTO;
using System.Collections.Generic;

namespace TravelApp.BLL.Interfaces
{
    public interface ICitiesWhichIWantToVisitService
    {
        ICollection<CitiesWhichIWantToVisitDTO> GetAllCitiesWhichIWantToVisit();
        ICollection<CityWhichIWantToVisitFullDTO> GetAllCitiesWhichIWantToVisitByUser(long userID);

        CityWhichIWantToVisitFullDTO GetFullCityWhichIWantToVisit(long id);
        CityWhichIWantToVisitFullDTO GetFullCityWhichIWantToVisitByName(string cityName);

        CitiesWhichIWantToVisitDTO GetCitiesWhichIWantToVisitById(long id);
        bool UpdateCitiesWhichIWantToVisit(CitiesWhichIWantToVisitDTO citiesWhichIWantToVisit);
        bool DeleteCitiesWhichIWantToVisit(long id);
        bool AddCitiesWhichIWantToVisit(CitiesWhichIWantToVisitDTO citiesWhichIWantToVisit);
    }
}
