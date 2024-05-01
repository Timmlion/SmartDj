using System.Net.Http.Json;
using SmartDj.Shared.DTO;
using SmartDj.Shared.Models;

namespace SmartDj.Gui.Services;

public class TemplateService(HttpClient httpClient)
{
    public async Task<FormTemplate> GetActiveTemplate()
    {
        var response = await httpClient.GetAsync(
            "api/Template/active");
        var serviceResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<FormTemplate>>();

        if (serviceResponse.Success)
        {
            return serviceResponse.Data;
        }
        //ToDo: implement error handling
        return null;
    }

    public async Task<bool> PostTemplate(FormTemplate formTemplate)
    {
        var response = await httpClient.PostAsJsonAsync(
            "api/Template", formTemplate);
        var serviceResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();

        return serviceResponse.Success;
    }

    public async Task<List<FormTemplate>> GetTemplates()
    {
        var response = await httpClient.GetAsync(
            "api/Template/all");
        var serviceResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<List<FormTemplate>>>();

        if (serviceResponse.Success)
        {
            return serviceResponse.Data;
        }
        //ToDo: implement error handling
        return null;
    }
}