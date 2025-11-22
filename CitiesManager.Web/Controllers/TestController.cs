using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CitiesManager.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [Route("[action]")]
        [HttpGet]
        public string MethodGet()
        {
            return "Hello World Get";
        }

        [Route("[action]")]
        [HttpPost]
        public string MethodPost()
        {
            return "Hello World Post";
        }

    }
}
