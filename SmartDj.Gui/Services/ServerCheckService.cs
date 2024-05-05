using System.Net;
using System.Net.Http.Json;
using SmartDj.Shared.Models;

namespace SmartDj.Gui.Services;

public class ServerCheckService(HttpClient httpClient)
{
    public async Task<bool> CheckServer()
    {
        try
        {
            var response = await httpClient.GetAsync("/api/Health");

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
