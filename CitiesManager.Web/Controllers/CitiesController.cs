using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CitiesManager.WebAPI.DatabaseContext;
using CitiesManager.Core.Domain.Models;
using CitiesManager.Core.ServiceContracts;
using CitiesManager.Core.DTO;

namespace CitiesManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly ICityGettersServices _cityGettersServices;
        private readonly ICityAdderService _cityAdderService;

        public CitiesController(ApplicationDbContext context, ICityGettersServices cityGettersServices, ICityAdderService cityAdderService)
        {   
            _context = context;
            _cityAdderService = cityAdderService;
            _cityGettersServices = cityGettersServices;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityResponse>>> GetCities()
        {
            return await _cityGettersServices.GetAllCities();
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityResponse>> GetCity(Guid id)
        {
            var city = await _cityGettersServices.GetCityByID(id);

            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        // PUT: api/Cities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(Guid id, City city)
        {
            if (id != city.CityID)
            {
                return BadRequest();
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
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CityResponse>> PostCity(CityAddRequest addRequest)
        {
            CityResponse addResponse = await _cityAdderService.AddCity(addRequest);

            return CreatedAtAction("GetCity", new { id = addResponse.CityID }, addResponse);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CityExists(Guid id)
        {
            return _context.Cities.Any(e => e.CityID == id);
        }
    }
}
