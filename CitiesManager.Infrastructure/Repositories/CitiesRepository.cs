using CitiesManager.Core.Domain.Models;
using CitiesManager.WebAPI.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitiesManager.Core.Domain.RepositoryContracts;

namespace CitiesManager.Infrastructure.Repositories
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly ApplicationDbContext _context;

        public CitiesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<City>> GetCities()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<City?> GetCity(Guid id)
        {
            var city = await _context.Cities.FirstOrDefaultAsync( temp => temp.CityID == id);

            if (city == null)
            {
                return null;
            }

            return city;
        }

        public async Task<City> PutCity(City updateCity)
        {
            City? matchingCity = await _context.Cities.FirstOrDefaultAsync(temp => temp.CityID == updateCity.CityID);

            if (matchingCity == null)
                return matchingCity;

            matchingCity.CityName = updateCity.CityName;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (GetCity(updateCity.CityID) is null)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return matchingCity;
        }

        public async Task<City> PostCity(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();

            return city;
        }

        public async Task<bool> DeleteCity(Guid id)
        {
            var city = await _context.Cities.FindAsync(id);
            
            if (city == null)
            {
                return false;
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
