using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartDj.Proxy.Services;

namespace SmartDj.Proxy.Controllers
{
    [Route("/")]
    [ApiController]
    public class ProxyController : ControllerBase
    {
        private ProxyService _proxyService;
        
        public ProxyController(ProxyService proxyService)
        {
            _proxyService = proxyService;
        }
        
        // GET api/<ProxyController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            if (_proxyService.CheckId(id))
            {
                
            }
            else
            {
                
            }
            
            return "Id: " + id;
        }

        // POST api/<ProxyController>
        [HttpPost("{id}")]
        public string Post([FromBody] string value, string id)
        {
            if (_proxyService.CheckId(id))
            {
                
            }
            else
            {
                
            }
            return "ID: " + id + " Value: " + value;
        }
    }
}
