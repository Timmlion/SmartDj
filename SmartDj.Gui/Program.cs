using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SmartDj.Gui;
using SmartDj.Gui.Services;



var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient());

builder.Services.AddScoped<SongRequestService>();
builder.Services.AddScoped<SettingService>();
builder.Services.AddScoped<TemplateService>();
builder.Services.AddScoped<ServerCheckService>();


builder.Services.AddBlazoredLocalStorage();

builder.Services.AddBlazorBootstrap();

await builder.Build().RunAsync();
