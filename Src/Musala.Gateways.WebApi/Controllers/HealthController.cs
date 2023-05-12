using Microsoft.AspNetCore.Mvc;

namespace Musala.Gateways.WebApi.Controllers
{
    [Route("ns-gateways/api/[controller]")]
    [ApiController]
    public class Health : ControllerBase
    {
        [HttpGet("GetHealthCheck")]
        public string Get()
        {
            return "i'm healthy";
        }

        public StatusCodeResult DefaultResponse()
        {
            return StatusCode(505);
        }
        
    }
}