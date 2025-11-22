using CitiesManager.Core.Domain.RepositoryContracts;
using CitiesManager.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesManager.Core.Services
{
    public class CityDeleterService : ICityDeleterService
    {
        private readonly ICitiesRepository _citiesRepository;

        public CityDeleterService(ICitiesRepository citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }

        public async Task<bool> DeleteCity(Guid? Id)
        {
            if (Id == null) 
                throw new ArgumentNullException( nameof(Id));

            return await _citiesRepository.DeleteCity(Id.Value);
        }
    }
}
