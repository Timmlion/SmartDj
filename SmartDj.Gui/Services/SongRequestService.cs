using System.Net.Http.Json;
using SmartDj.Shared.DTO;
using SmartDj.Shared.Models;

namespace SmartDj.Gui.Services;

public class SongRequestService(HttpClient httpClient)
{
    
    public async Task<IEnumerable<SongRequest>?> GetSongRequests()
    {
        var response = await httpClient.GetAsync("api/RequestedSongs");
        response.EnsureSuccessStatusCode();

        var serviceResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<List<SongRequest>>>();

        if (serviceResponse.Success)
        {
            return serviceResponse.Data;
        }

        return null;
    }

    public async Task<bool> UpdateSongRequest(int id, bool wasPlayed)
    {
        var response = await httpClient.PostAsJsonAsync(
            "api/RequestedSongs",new PostSongRequestUpdateDto
            {
                Id = id, WasPlayed = wasPlayed
            });
        var serviceResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();

        if (serviceResponse.Data && serviceResponse.Success)
        {
            return true;
        }

        return false;
    }
}