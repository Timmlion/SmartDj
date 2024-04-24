using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using SmartDJ.Server;
using SmartDj.Server.DTO;
using SmartDj.Server.Services;

namespace SmartDj.Server.Controllers.Public
{
    [Route("public")]
    [ApiController]
    public class SongRequestController : ControllerBase
    {

        private SongRequestService _songRequestService;
        private FormTemplateService _formTemplateService;

        public SongRequestController(
            SongRequestService songRequestService,
            FormTemplateService formTemplateService
            )
        {
            _songRequestService = songRequestService;
            _formTemplateService = formTemplateService;
        }
        
        [HttpPost("[controller]")]
        public ServiceResponse<int> Post([FromBody] PostSongRequestDTO songRequestDto)
        {
            return _songRequestService.AddSongToList(songRequestDto);
        }

        [HttpGet("Webform")]
        public IActionResult Get()
        {
            var formContent = _formTemplateService.GetActiveTemplate();

            if (formContent.Success)
            {
                return Content(formContent.Data.HtmlContent, "text/html");
            }

            return StatusCode(418);

        }
    }
}
