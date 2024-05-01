using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartDj.Server.Services;
using SmartDj.Shared.Models;

namespace SmartDj.Server.Controllers.UIClient
{
    [Route("api/[controller]")]
    [ApiController]
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

        // POST: post template
        [HttpPost]
        public ServiceResponse<string> Post([FromBody] string templateContent)
        {
            return _formTemplateService.AddTemplate(templateContent);

        }

        // DELETE: dalete template by id
        [HttpDelete("{id}")]
        public ServiceResponse<string> Delete(int id)
        {
            return _formTemplateService.RemoveTemplate(id);
        }
    }
}
