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
    public class CityAdderService : ICityAdderService
    {
        private readonly ICitiesRepository _citiesRepository;

        public CityAdderService(ICitiesRepository citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }

        public async Task<CityResponse> AddCity(CityAddRequest request)
        {
            City newCity = request.ToCity();
            newCity.CityID = Guid.NewGuid();

            await _citiesRepository.PostCity(newCity);

            return newCity.ToCityResponse();
        }
    }
}
