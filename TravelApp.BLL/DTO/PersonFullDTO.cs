using System;
using System.Collections.Generic;
using System.Text;

namespace TravelApp.BLL.DTO
{
    public class PersonFullDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public ICollection<CitiesWhichIVisitedDTO> citiesVisited { get; set; }
        public ICollection<CitiesWhichIWantToVisitDTO> citiesWant { get; set; }
        public ICollection<PhotoDTO> photos { get; set; }
        public ICollection<CommentDTO> commnets { get; set; }
    }
}
