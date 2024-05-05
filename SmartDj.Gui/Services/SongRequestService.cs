using System.Net.Http.Json;
using SmartDj.Shared.DTO;
using SmartDj.Shared.Models;

namespace SmartDj.Gui.Services;

public class SongRequestService(HttpClient httpClient, SettingService settingService)
{
    private string? _baseAddress;
    public async Task SetSettings()
    {
        if (string.IsNullOrEmpty(_baseAddress))
        {
            _baseAddress = await settingService.GetBaseAddress();
        }
    }
    
    public async Task<IEnumerable<SongRequest>?> GetSongRequests()
    {
        await SetSettings();
        var response = await httpClient.GetAsync(_baseAddress+"api/RequestedSongs");
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
        await SetSettings();
        var response = await httpClient.PostAsJsonAsync(
            _baseAddress+"api/RequestedSongs",new PostSongRequestUpdateDto
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

    public async Task<bool> ClearRequestSongsList()
    {
        await SetSettings();
        var response = await httpClient.DeleteAsync(_baseAddress+"api/RequestedSongs");
        var serviceResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        
        if (serviceResponse.Data && serviceResponse.Success)
        {
            return true;
        }
        return false;
    }
}