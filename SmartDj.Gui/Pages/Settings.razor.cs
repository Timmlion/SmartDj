using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using SmartDj.Gui.Services;

namespace SmartDj.Gui.Pages;

public partial class Settings : ComponentBase
{
    [Inject]
    private SongRequestService _songRequestService { get; set; }
    [Inject]
    private SettingService _settingService { get; set; }
    [Inject]
    private NavigationManager NavigationManager { get; set; }
    
    private Modal modal = default!;

    private string baseAddress;

    protected override async Task OnInitializedAsync()
    {
        baseAddress = await _settingService.GetBaseAddress();
    }

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

    private async Task SaveBaseAddress()
    {
        await _settingService.AddBaseAddress(baseAddress);
        NavigationManager.NavigateTo("settings", true);
    }
}