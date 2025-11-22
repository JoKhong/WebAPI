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

        // GET: api/Cities
       
        public async Task<List<City>> GetCities()
        {
            return await _context.Cities.ToListAsync();
        }

        // GET: api/Cities/5
       
        public async Task<City?> GetCity(Guid id)
        {
            var city = await _context.Cities.FindAsync(id);

            if (city == null)
            {
                return city;
            }

            return city;
        }

        // PUT: api/Cities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      
        public async Task<bool> PutCity(Guid id, City city)
        {
            if (id != city.CityID)
            {
                return false;
            }

            _context.Entry(city).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return false;
        }

        // POST: api/Cities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       
        public async Task<City> PostCity(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();

            return city;
        }

        // DELETE: api/Cities/5
       
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

        private bool CityExists(Guid id)
        {
            return _context.Cities.Any(e => e.CityID == id);
        }
    }
}
