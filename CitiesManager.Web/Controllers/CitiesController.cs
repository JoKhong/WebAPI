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
        private readonly ICityGettersServices _cityGettersServices;
        private readonly ICityAdderService _cityAdderService;
        private readonly ICityUpdateService _cityUpdateService;
        private readonly ICityDeleterService _cityDeleterService;

        public CitiesController(
            ICityGettersServices cityGettersServices, 
            ICityAdderService cityAdderService, 
            ICityUpdateService cityUpdateService, 
            ICityDeleterService cityDeleterService)
        {   
            _cityAdderService = cityAdderService;
            _cityGettersServices = cityGettersServices;
            _cityUpdateService = cityUpdateService;
            _cityDeleterService = cityDeleterService;
        }

        // GET: api/Cities
        /// <summary>
        /// Get list of all cities, (ID and Name) from "cities" table
        /// </summary>
        /// <returns></returns>
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
        public async Task<IActionResult> PutCity(Guid id, CityUpdateRequest updateRequest)
        {
            if (id != updateRequest.CityID)
            {
                return BadRequest();
            }

            await _cityUpdateService.UpdateCity(updateRequest);

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
        public async Task<IActionResult> DeleteCity(Guid? id)
        {
            if (id == null)
                return Problem(
                    detail: "Id is null",
                    statusCode: 400,
                    title:"City Delete"
                    );

            await _cityDeleterService.DeleteCity(id);

            return NoContent();
        }

    }
}
