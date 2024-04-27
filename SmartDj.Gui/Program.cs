using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SmartDj.Gui;
using SmartDj.Gui.Services;



var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5096/") });
builder.Services.AddScoped<SongRequestService>();
builder.Services.AddBlazorBootstrap();

await builder.Build().RunAsync();
