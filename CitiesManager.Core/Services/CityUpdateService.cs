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
    public class CityUpdateService : ICityUpdateService
    {
        private readonly ICitiesRepository _citiesRepository;

        public CityUpdateService(ICitiesRepository citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }

        public async Task<CityResponse?> UpdateCity(CityUpdateRequest? updateRequest)
        {
            if(updateRequest == null) 
                throw new ArgumentNullException(nameof(updateRequest));

            City? matchingCity = await _citiesRepository.GetCity(updateRequest.CityID);

            if (matchingCity == null)
                return null;

            matchingCity.CityName = updateRequest.CityName;

            await _citiesRepository.PutCity(matchingCity);

            return matchingCity.ToCityResponse();

        }
    }
}
