using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using SmartDj.Gui.Services;
using SmartDj.Shared.Models;

namespace SmartDj.Gui.Components;

public partial class SongRequestGrid : ComponentBase
{
    [Inject]
    private SongRequestService _songRequestService { get; set; }
    
    BlazorBootstrap.Grid<SongRequest> grid = default!;
    private IEnumerable<SongRequest> songRequests = default!;

    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        StartTimer(10);
    }

    private async Task StartTimer(int secconds)
    {
        var timer = new PeriodicTimer(TimeSpan.FromSeconds(secconds));

        while (await timer.WaitForNextTickAsync())
        {
            grid.RefreshDataAsync();   
        }
    }

    private async Task<GridDataProviderResult<SongRequest>> SongRequestDataProvider(GridDataProviderRequest<SongRequest> request)
    { 
        songRequests = await _songRequestService.GetSongRequests(); 
        return await Task.FromResult(request.ApplyTo(songRequests));
    }


    private async Task UpdateSongRequest(int id, bool wasPlayed)
    {
        var success =  await _songRequestService.UpdateSongRequest(id, wasPlayed);
        if (!success)
        {
            //ToDo: Add modal
        }
        else
        {
            grid.RefreshDataAsync(); 
        }  
    }
}