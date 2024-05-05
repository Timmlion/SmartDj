using Microsoft.AspNetCore.Components;
using SmartDj.Gui.Services;

namespace SmartDj.Gui.Pages;

public partial class Home : ComponentBase
{
    [Inject]
    private ServerCheckService _serverCheckService { get; set; }

    private bool _isConnectedToServer;
    
    protected override async Task OnInitializedAsync()
    {
        _isConnectedToServer = await _serverCheckService.CheckServer();
    }
}