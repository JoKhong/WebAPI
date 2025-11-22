using CitiesManager.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesManager.Core.DTO
{
    public class CityAddRequest
    {
        public string? CityName {  get; set; }

        public City ToCity()
        {
            City city = new City()
            {
                CityName = CityName
            };

            return city;
        }
    }
}
