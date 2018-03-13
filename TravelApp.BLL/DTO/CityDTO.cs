using System;
using System.Collections.Generic;
using System.Text;

namespace TravelApp.BLL.DTO
{
    public class CityDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public double Rating { get; set; }
    }
}
