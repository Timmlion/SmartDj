using System.Net.Http.Json;
using SmartDj.Shared.DTO;
using SmartDj.Shared.Models;

namespace SmartDj.Gui.Services;

public class TemplateService(HttpClient httpClient, SettingService settingService)
{
    private string? _baseAddress;
    public async Task SetSettings()
    {
        if (string.IsNullOrEmpty(_baseAddress))
        {
            _baseAddress = await settingService.GetBaseAddress();
        }
    }

    public async Task<FormTemplate> GetActiveTemplate()
    {
        await SetSettings();
        var response = await httpClient.GetAsync(
            _baseAddress+"api/Template/active");
        var serviceResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<FormTemplate>>();

        if (serviceResponse.Success)
        {
            return serviceResponse.Data;
        }
        //ToDo: implement error handling
        return null;
    }

    public async Task<bool> PostTemplate(PostTemplateDto formTemplate)
    {
        await SetSettings();
        var response = await httpClient.PostAsJsonAsync(
            _baseAddress+"api/Template", formTemplate);
        var serviceResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();

        return serviceResponse.Success;
    }

    public async Task<List<FormTemplate>> GetTemplates()
    {
        await SetSettings();
        var response = await httpClient.GetAsync(
            _baseAddress+"api/Template/all");
        var serviceResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<List<FormTemplate>>>();

        if (serviceResponse.Success)
        {
            return serviceResponse.Data;
        }
        //ToDo: implement error handling
        return null;
    }

    public async Task<bool> SetTemplateAsActive(int contextId)
    {
        await SetSettings();
        var response = await httpClient.GetAsync(
            _baseAddress+"api/Template/setActive/"+contextId);
        var serviceResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();

        return serviceResponse.Success;
    }

    public async Task<bool> RemoveTemplate(int contextId)
    {
        await SetSettings();
        var response = await httpClient.DeleteAsync(
            _baseAddress+"api/Template/"+contextId);
        var serviceResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();

        return serviceResponse.Success;
    }
}