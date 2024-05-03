using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using SmartDj.Gui.Services;
using SmartDj.Shared.Models;

namespace SmartDj.Gui.Pages;

public partial class Template : ComponentBase
{
    [Inject] 
    private TemplateService _templateService { get; set; }
    
    private string _templateContent = "";
    
    BlazorBootstrap.Grid<FormTemplate> grid = default!;
    private IEnumerable<FormTemplate> formTemplates = default!;
    
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
    }

    private async Task<GridDataProviderResult<FormTemplate>> FormTemplateDataProvider(GridDataProviderRequest<FormTemplate> request)
    { 
        formTemplates = await _templateService.GetTemplates(); 
        return await Task.FromResult(request.ApplyTo(formTemplates));
    }
    
    private async Task LoadActiveTemplate()
    {
        FormTemplate formTemplate = await _templateService.GetActiveTemplate();

        _templateContent = formTemplate.HtmlContent;
    }

    private async Task SaveTemplateChanges()
    {
        /*_formTemplate.HtmlContent = _templateContent;
        _templateService.PostTemplate(_formTemplate);*/
    }

    private async Task SetAsActive(int contextId)
    {
        await _templateService.SetTemplateAsActive(contextId);
        grid.RefreshDataAsync(); 
    }
}