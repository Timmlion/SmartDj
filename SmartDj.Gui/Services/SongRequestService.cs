using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
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
}