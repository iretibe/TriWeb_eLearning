using Blazored.Toast;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using eLearning.UI.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services
    .AddBlazorise(options => { options.Immediate = true; })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();

// Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var backendUrl = builder.Configuration["ApiUrls:BackendUrl"];

builder.Services.AddScoped(sp => 
    new HttpClient 
    { 
        BaseAddress = new Uri(backendUrl!) 
    });

//builder.Services.AddScoped(sp =>
//    new HttpClient
//    {
//        BaseAddress = new Uri(builder.Configuration["ApiUrls:BackendUrl"] ?? "https://localhost:7012")
//        //BaseAddress = new Uri("https://localhost:7254")
//    });

builder.Services
    .AddScoped<ICourseService, CourseClientService>();

builder.Services.AddBlazoredToast();

await builder.Build().RunAsync();
