using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesManager.Core.ServiceContracts
{
    public interface ICityDeleterService
    {
        Task<bool> DeleteCity(Guid? Id);
    }
}
