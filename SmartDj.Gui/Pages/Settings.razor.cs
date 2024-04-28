using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using SmartDj.Gui.Services;

namespace SmartDj.Gui.Pages;

public partial class Settings : ComponentBase
{
    [Inject]
    private SongRequestService _songRequestService { get; set; }
    
    private Modal modal = default!;

    private async Task ShowClearListModal()
    {
        await modal.ShowAsync();
    }

    private async Task HideClearListModal()
    {
        await modal.HideAsync();
    }

    private async Task ClearSongList()
    {
        var result = await _songRequestService.ClearRequestSongsList();
        
        if (!result)
        {
            //ToDo: Add Modal
        }
        else
        {
            //ToDo: Add Modal
        }
        
        HideClearListModal();
    }
}