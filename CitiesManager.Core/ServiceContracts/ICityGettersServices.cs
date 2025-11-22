using CitiesManager.Core.Domain.Models;
using CitiesManager.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesManager.Core.ServiceContracts
{
    public interface ICityGettersServices
    {
        Task<List<CityResponse>> GetAllCities();
        Task<CityResponse?> GetCityByID(Guid? Id);

    }
}
