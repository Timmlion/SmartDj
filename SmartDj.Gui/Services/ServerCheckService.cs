using System.Net;
using System.Net.Http.Json;
using SmartDj.Shared.Models;

namespace SmartDj.Gui.Services;

public class ServerCheckService(HttpClient httpClient, SettingService settingService)
{
    private string? _baseAddress;
    public async Task SetSettings()
    {
        if (string.IsNullOrEmpty(_baseAddress))
        {
            _baseAddress = await settingService.GetBaseAddress();
        }
    }

    public async Task<bool> CheckServer()
    {
        await SetSettings(); 
        try
        {
            var response = await httpClient.GetAsync(_baseAddress+"api/Health");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
        }
        catch
        {
        }
        return false;
    }
}
