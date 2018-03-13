using System;
using System.Collections.Generic;
using System.Text;

namespace TravelApp.BLL.DTO
{
    public class CityWhichIVisitedFullDTO
    {
        public long Id { get; set; }

        public long? CityId { get; set; }

        public ICollection<PersonDTO> PersonId { get; set; }
    }
}
