using System;

namespace TravelApp.BLL.DTO
{
    public class CommentDTO
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public long? PersonId { get; set; }
        public long? CityId { get; set; }
    }
}
