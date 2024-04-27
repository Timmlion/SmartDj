using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using SmartDj.Shared.Models;

namespace SmartDj.Gui.Pages;

public partial class Home : ComponentBase
{
    BlazorBootstrap.Grid<SongRequest> grid = default!;
    private IEnumerable<SongRequest> songRequests = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
    }

    private async Task<GridDataProviderResult<SongRequest>> SongRequestDataProvider(GridDataProviderRequest<SongRequest> request)
    {
        if (songRequests is null) // pull employees only one time for client-side filtering, sorting, and paging
            songRequests = GetSongRequests(); // call a service or an API to pull the employees

        return await Task.FromResult(request.ApplyTo(songRequests));
    }

    private IEnumerable<SongRequest> GetSongRequests()
    {
        return new List<SongRequest>
        {
            new SongRequest{Id = 1, DateCreated = DateTime.Now, RequestorName = "Zuzia", DedicateeName = "Zbigniew", SongTitle = "Tytuł piosenki", Message = "Dedykacja, Lorem ipsum pipsum sripsum tripsum bombiksum fafarafa fifirafifo", WasPlayed = true},
            new SongRequest{Id = 2, DateCreated = DateTime.Now, RequestorName = "Zuzia2", DedicateeName = "Zbigniew", SongTitle = "Tytuł piosenki", Message = "Dedykacja, Lorem ipsum pipsum sripsum tripsum bombiksum fafarafa fifirafifo", WasPlayed = false},
            new SongRequest{Id = 3, DateCreated = DateTime.Now, RequestorName = "Zuzia3", DedicateeName = "Zbigniew", SongTitle = "Tytuł piosenki", Message = "Dedykacja, Lorem ipsum pipsum sripsum tripsum bombiksum fafarafa fifirafifo", WasPlayed = false},
            new SongRequest{Id = 4, DateCreated = DateTime.Now, RequestorName = "Zuzia4", DedicateeName = "Zbigniew", SongTitle = "Tytuł piosenki", Message = "Dedykacja, Lorem ipsum pipsum sripsum tripsum bombiksum fafarafa fifirafifo", WasPlayed = false},
        };
    }
}