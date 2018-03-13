using TravelApp.BLL.DTO;
using System.Collections.Generic;

namespace TravelApp.BLL.Interfaces
{
    public interface IAdministratorService
    {
        ICollection<AdministratorDTO> GetAllAdministrator();
        AdministratorDTO GetAdministratorById(int id);
        bool UpdateAdministrator(AdministratorDTO administrator);
        bool DeleteAdministrator(int id);
        bool AddAdministrator(AdministratorDTO administrator);
    }
}
