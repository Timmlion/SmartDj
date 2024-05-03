using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using SmartDj.Gui.Services;
using SmartDj.Shared.DTO;
using SmartDj.Shared.Models;

namespace SmartDj.Gui.Pages;

public partial class Template : ComponentBase
{
    [Inject] 
    private TemplateService _templateService { get; set; }

    public int TemplateId { get; set; } 
    public string TemplateName { get; set; } = String.Empty;
    public string TemplateContent { get; set; } = String.Empty;
    
    BlazorBootstrap.Grid<FormTemplate> grid = default!;
    private IEnumerable<FormTemplate> formTemplates = default!;
    
    private Modal xlModal = default!;
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
    }

    private async Task<GridDataProviderResult<FormTemplate>> FormTemplateDataProvider(GridDataProviderRequest<FormTemplate> request)
    { 
        formTemplates = await _templateService.GetTemplates(); 
        return await Task.FromResult(request.ApplyTo(formTemplates));
    }

    private async Task SaveTemplate()
    {
        var postTemplate = new PostTemplateDto();
        postTemplate.Id = TemplateId;
        postTemplate.Name = TemplateName;
        postTemplate.TemplateContent = TemplateContent;
        
        var sucess = await _templateService.PostTemplate(postTemplate);
        //ToDo: Add model for status
        
        xlModal.HideAsync();
        grid.RefreshDataAsync(); 
    }

    private async Task SetAsActive(int contextId)
    {
        await _templateService.SetTemplateAsActive(contextId);
        grid.RefreshDataAsync();
    }

    private void ShowModalTemplate(int? id)
    {
        //I know its ugly... I will change that... for sure...
        if (id != null)
        {
            var template = formTemplates.Where(t => t.Id == id).FirstOrDefault();
            TemplateId = template.Id;
            TemplateName = template.Name;
            TemplateContent = template.HtmlContent;
        }
        else
        {
            TemplateId = 0;
            TemplateName = String.Empty;
            TemplateContent = String.Empty;
        }

        xlModal.ShowAsync();
    }

    private async Task RemoveModal(int contextId)
    {
        var sucess = await _templateService.RemoveTemplate(contextId);
        //ToDo: add toast
        grid.RefreshDataAsync();     
    }
}