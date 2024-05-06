using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartDj.Server.Services;
using SmartDj.Shared.DTO;
using SmartDj.Shared.Models;

namespace SmartDj.Server.Controllers.UIClient
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")] 
    public class TemplateController : ControllerBase
    {
        private FormTemplateService _formTemplateService;
        
        public TemplateController(FormTemplateService formTemplateService)
        {
            _formTemplateService = formTemplateService;
        }
        
        // GET: get all templates
        [HttpGet("all")]
        public ServiceResponse<List<FormTemplate>> GetAll()
        {
            return _formTemplateService.GetAllTemplates();
        }

        // GET: get active template
        [HttpGet("active")]
        public ServiceResponse<FormTemplate> GetActive()
        {
            return _formTemplateService.GetActiveTemplate();
        }

        // GET: get template by id
        [HttpGet("{id}")]
        public ServiceResponse<FormTemplate> Get(int id)
        {
            return _formTemplateService.GetTemplateByID(id);
        }
        // GET: get template by id
        [HttpGet("setActive/{id}")]
        public ServiceResponse<bool> SetAsAvctive(int id)
        {
            return _formTemplateService.SetAsActive(id);
        }

        // POST: post template
        [HttpPost]
        public ServiceResponse<bool> Post([FromBody] PostTemplateDto postTemplateDto)
        {
            return _formTemplateService.AddUpdateTemplate(postTemplateDto);

        }

        // DELETE: dalete template by id
        [HttpDelete("{id}")]
        public ServiceResponse<bool> Delete(int id)
        {
            return _formTemplateService.RemoveTemplate(id);
        }
    }
}
