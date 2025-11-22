using CitiesManager.Core.Domain.Models;
using CitiesManager.Core.Domain.RepositoryContracts;
using CitiesManager.Core.DTO;
using CitiesManager.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesManager.Core.Services
{
    public class CityGetterServices : ICityGettersServices
    {
        private readonly ICitiesRepository _citiesRepository;

        public CityGetterServices(ICitiesRepository citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }

        public async Task<List<CityResponse>> GetAllCities()
        {
            List<City> cities = await _citiesRepository.GetCities();

            var citiesResponse = cities.Select(city => city.ToCityResponse()).ToList();
            return citiesResponse;
        }

        public async Task<CityResponse?> GetCityByID(Guid? Id)
        {
            if (Id == null)
                return null;

            City? response = await _citiesRepository.GetCity(Id.Value);

            if (response == null)
                return null;

            return response.ToCityResponse();
        }
    }
}
