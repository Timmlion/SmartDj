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
    }

    private async Task<GridDataProviderResult<SongRequest>> SongRequestDataProvider(GridDataProviderRequest<SongRequest> request)
    {
        if (songRequests is null) // pull employees only one time for client-side filtering, sorting, and paging
            songRequests = await _songRequestService.GetSongRequests(); // call a service or an API to pull the employees

        return await Task.FromResult(request.ApplyTo(songRequests));
    }

    
}