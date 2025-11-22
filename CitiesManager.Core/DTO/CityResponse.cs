using CitiesManager.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CitiesManager.Core.DTO
{
    public class CityResponse
    {
        public Guid CityID {  get; set; }
        public string? CityName { get; set; }

        public CityUpdateRequest ToCityUpdateRequest()
        {
            CityUpdateRequest ret = new CityUpdateRequest()
            {
                CityID = this.CityID,
                CityName = this.CityName
            };
            return ret;
        }

    }

    public static class CityExtension
    {
        public static CityResponse ToCityResponse(this City city)
        {
            CityResponse response = new CityResponse()
            {
                CityID = city.CityID,
                CityName = city.CityName
            };

            return response;
        }
    }

}
