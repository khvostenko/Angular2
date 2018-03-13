using System;

namespace TravelApp.DAL.Models
{
    public class Photo
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }

        public long? PersonId { get; set; }
        public long? CityId { get; set; }

        public virtual Person Person { get; set; }
        public virtual City City { get; set; }
    }
}
