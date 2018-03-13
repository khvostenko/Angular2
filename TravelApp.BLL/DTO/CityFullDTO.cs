using System;
using System.Collections.Generic;
using System.Text;

namespace TravelApp.BLL.DTO
{
    public class CityFullDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public double Rating { get; set; }

        public ICollection<CommentDTO> comments { get; set; }
        public ICollection<PhotoDTO> photos { get; set; }
    }
}
