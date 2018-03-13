using TravelApp.BLL.DTO;
using System.Collections.Generic;
using System.Linq;

namespace TravelApp.BLL.Interfaces
{
    public interface IPersonService
    {
        ICollection<PersonDTO> GetAllPersons();
        ICollection<PersonDTO> GetAllPersonsByName(string personName);
        PersonFullDTO GetPersonFullDTO(long id);

        PersonDTO GetPersonById(int id);
        bool UpdatePerson(PersonDTO person);
        bool DeletePerson(int id);
        bool AddPerson(PersonDTO person);
    }
}
