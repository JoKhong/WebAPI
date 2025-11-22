using CitiesManager.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CitiesManager.Core.Domain.RepositoryContracts
{
    public interface ICitiesRepository
    {
        Task<List<City>> GetCities();
        Task<City?> GetCity(Guid id);
        Task<City?> PutCity(City city);
        Task<City> PostCity(City city);
        Task<bool> DeleteCity(Guid id);
        
    }
}
