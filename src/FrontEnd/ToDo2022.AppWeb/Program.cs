using Majorsoft.Blazor.Components.Common.JsInterop;
using Majorsoft.Blazor.Components.CssEvents;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//AppManager
builder.Services.AddSingleton(new AppManager());
AppManager appManager = builder.Services.BuildServiceProvider().GetRequiredService<AppManager>();




//SyHttpClient_ToDo2022
//string URL_TODO2022_API = "https://localhost:7091/v1/";
string URL_TODO2022_API = "https://todo2022-api.azurewebsites.net/v1/";

builder.Services.AddSingleton(new SyHttpClient_ToDo2022("TODO", URL_TODO2022_API));
appManager.SyHttpClients.Add("", builder.Services.BuildServiceProvider().GetRequiredService<SyHttpClient_ToDo2022>());

//Agregados para Majorsoft.Blazor.Components.CssEvents
builder.Services.AddCssEvents();
builder.Services.AddJsInteropExtensions();
builder.Services.AddMudServices();
await builder.Build().RunAsync();




