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
        [HttpGet]
        public ActionResult<IEnumerable<FormTemplate>> GetAll()
        {
            var allTemplatesSR = _formTemplateService.GetAllTemplates();

            if (allTemplatesSR.Success)
            {
                return Ok(allTemplatesSR.Data);
            }
            else
            {
                return Problem(allTemplatesSR.Message);
            }
        }

        // GET: get active template
        [HttpGet("active")]
        public ActionResult<FormTemplate> GetActive()
        {
            var activeTemplateSR = _formTemplateService.GetActiveTemplate();

            if (activeTemplateSR.Success)
            {
                return Ok(activeTemplateSR.Data);
            }
            else
            {
                return Problem(activeTemplateSR.Message);
            }
        }

        // GET: get template by id
        [HttpGet("{id}")]
        public ActionResult<FormTemplate> Get(int id)
        {
            var templateSR = _formTemplateService.GetTemplateByID(id);

            if (templateSR.Success)
            {
                return Ok(templateSR.Data);
            }
            else
            {
                return Problem(templateSR.Message);
            }
        }

        // POST: post template
        [HttpPost]
        public IActionResult Post([FromBody] string templateContent)
        {
            var result = _formTemplateService.AddTemplate(templateContent);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return Problem(result.Message);
            }
        }

        // DELETE: dalete template by id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _formTemplateService.RemoveTemplate(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return Problem(result.Message);
            }
        }
    }
}
