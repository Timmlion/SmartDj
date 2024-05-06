using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SmartDj.Server.Services;
using SmartDj.Shared.DTO;
using SmartDj.Shared.Models;

namespace SmartDj.Server.Controllers.Public
{
    [Route("public")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")] 
    public class PublicController : ControllerBase
    {

        private SongRequestService _songRequestService;
        private FormTemplateService _formTemplateService;

        public PublicController(
            SongRequestService songRequestService,
            FormTemplateService formTemplateService
        )
        {
            _songRequestService = songRequestService;
            _formTemplateService = formTemplateService;
        }

        [HttpPost("request")]
        public ServiceResponse<int> Post([FromBody] PostSongRequestDTO songRequestDto)
        {
            return _songRequestService.AddSongToList(songRequestDto);
        }

        [HttpGet("template")]
        public IActionResult Get()
        {
            var formContent = _formTemplateService.GetActiveTemplate();

            if (formContent.Success)
            {
                return Content(formContent.Data.HtmlContent, "text/html");
            }
            return Content(hardcodedDefaultTemplate, "text/html");

        }

        private string hardcodedDefaultTemplate =
            "<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n<meta charset=\"UTF-8\">\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n<title>Form Error</title>\n<style>\n    body {\n        margin: 0;\n        padding: 0;\n        display: flex;\n        justify-content: center;\n        align-items: center;\n        height: 100vh;\n        font-family: Arial, sans-serif;\n        background-color: #f7f7f7;\n    }\n    .container {\n        text-align: center;\n    }\n    h1 {\n        font-size: 24px;\n        color: #333;\n    }\n    p {\n        font-size: 18px;\n        color: #666;\n    }\n    @media (max-width: 600px) {\n        h1 {\n            font-size: 20px;\n        }\n        p {\n            font-size: 16px;\n        }\n    }\n</style>\n</head>\n<body>\n    <div class=\"container\">\n        <h1>Sorry, problem with the form</h1>\n        <p>Contact the DJ</p>\n    </div>\n</body>\n</html>\n";
    }
}
