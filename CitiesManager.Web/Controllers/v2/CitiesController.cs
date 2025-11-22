using Asp.Versioning;
using CitiesManager.Core.Domain.Models;
using CitiesManager.Core.DTO;
using CitiesManager.Core.ServiceContracts;
using CitiesManager.WebAPI.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesManager.WebAPI.Controllers.v2
{

    //[ApiVersion("2.0")]

    //public class CitiesController : CustomControllerBase
    //{
    //    private readonly ICityGettersServices _cityGettersServices;
    //    private readonly ICityAdderService _cityAdderService;
    //    private readonly ICityUpdateService _cityUpdateService;
    //    private readonly ICityDeleterService _cityDeleterService;

    //    public CitiesController(
    //        ICityGettersServices cityGettersServices,
    //        ICityAdderService cityAdderService,
    //        ICityUpdateService cityUpdateService,
    //        ICityDeleterService cityDeleterService)
    //    {
    //        _cityAdderService = cityAdderService;
    //        _cityGettersServices = cityGettersServices;
    //        _cityUpdateService = cityUpdateService;
    //        _cityDeleterService = cityDeleterService;
    //    }

    //    // GET: api/Cities
    //    /// <summary>
    //    /// Get list of all cities, (Name) from "cities" table
    //    /// </summary>
    //    /// <returns></returns>
    //    [HttpGet]
    //    //[Produces("application/xml")] Produce XML instead of JSON
    //    public async Task<ActionResult<IEnumerable<string?>>> GetCities()
    //    {
    //        List<CityResponse>? cityResponses = await _cityGettersServices.GetAllCities();

    //        List<string?> cityNames = cityResponses.Select(temp => temp.CityName).ToList();

    //        return cityNames;
    //    }
    //}

}
