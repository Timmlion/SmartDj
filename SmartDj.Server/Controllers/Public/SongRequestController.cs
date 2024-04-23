using Microsoft.AspNetCore.Mvc;
using SmartDJ.Server;
using SmartDj.Server.DTO;
using SmartDj.Server.Services;

namespace SmartDj.Server.Controllers.Public
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongRequestController : ControllerBase
    {

        private SongRequestService _songRequestService;

        public SongRequestController(SongRequestService songRequestService)
        {
            _songRequestService = songRequestService;
        }
        
        [HttpPost]
        public ServiceResponse<int> Post([FromBody] PostSongRequestDTO songRequestDto)
        {
            return _songRequestService.AddSongToList(songRequestDto);
        }
    }
}
