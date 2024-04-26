using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartDj.Server.Services;
using SmartDj.Shared.Models;

namespace SmartDj.Server.Controllers.UIClient
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestedSongsController : ControllerBase
    {
        private SongRequestService _songRequestService;

        public RequestedSongsController(SongRequestService songRequestService)
        {
            _songRequestService = songRequestService;
        }
        
        // Get requested songs
        [HttpGet]
        public ServiceResponse<List<SongRequest>> Get()
        {
            return _songRequestService.GetRequestedSongsList();
        }
        
        // Clear song request list
        [HttpDelete]
        public ServiceResponse<string> Delete()
        {
            return _songRequestService.ClearSongList();
        }
    }
}
