using eLearning.Web.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var backendUrl = builder.Configuration["ApiUrls:BackendUrl"];

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(backendUrl!)
    });

builder.Services
    .AddScoped<ICourseService, CourseClientService>();

await builder.Build().RunAsync();
