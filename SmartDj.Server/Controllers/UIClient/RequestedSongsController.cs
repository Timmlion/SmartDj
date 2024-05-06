using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartDj.Server.Services;
using SmartDj.Shared.DTO;
using SmartDj.Shared.Models;

namespace SmartDj.Server.Controllers.UIClient
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")] 
    public class RequestedSongsController : ControllerBase
    {
        private SongRequestService _songRequestService;

        public RequestedSongsController(SongRequestService songRequestService)
        {
            _songRequestService = songRequestService;
        }
        
        // Get requested songs
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_songRequestService.GetRequestedSongsList());
        }
        
        // Clear song request list
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok(_songRequestService.ClearSongList());
        }

        [HttpPost]
        public IActionResult UpdateSongRequest([FromBody]PostSongRequestUpdateDto songRequestUpdate)
        {
            return Ok(_songRequestService.UpdateSongRequest(songRequestUpdate));
        }
    }
}
