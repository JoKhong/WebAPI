using CitiesManager.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CitiesManager.Core.DTO
{
    public class CityUpdateRequest
    {
        public Guid CityID { get; set; }
        public string? CityName { get; set; }

        public City ToCity()
        {
            City city = new City
            {
                CityID = CityID,
                CityName = CityName,
            };

            return city;
        }

    }
}
