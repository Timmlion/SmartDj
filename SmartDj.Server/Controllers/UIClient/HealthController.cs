using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace SmartDj.Server.Controllers.UIClient
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")] 
    public class HealthController : ControllerBase
    {
        // GET: api/<HealthController>
        [HttpGet]
        public OkObjectResult Get()
        {
            return Ok("Server is responding");
        }

    }
}
