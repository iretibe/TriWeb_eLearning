using Blazored.SessionStorage;
using eLearning.WebApp.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

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

builder.Services
    .AddScoped<ICourseService, CourseClientService>()
    .AddScoped<IOrderService, OrderClientService>()
    .AddScoped<IUserService, UserClientService>()
    .AddScoped<IPaymentService, PaymentClientService>();

builder.Services.AddScoped<CartService>();

builder.Services.AddBlazoredSessionStorage();

await builder.Build().RunAsync();
