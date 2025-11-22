using CitiesManager.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesManager.Core.ServiceContracts
{
    public interface ICityAdderService
    {
        Task<CityResponse> AddCity(CityAddRequest request);
    }
}
