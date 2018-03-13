using System;
using System.Collections.Generic;
using System.Text;

namespace TravelApp.BLL.DTO
{
    public class PhotoDTO
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }

        public long? PersonId { get; set; }
        public long? CityId { get; set; }
    }
}
