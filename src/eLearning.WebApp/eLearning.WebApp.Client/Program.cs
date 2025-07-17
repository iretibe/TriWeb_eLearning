using Blazored.SessionStorage;
using eLearning.WebApp.Client.Helpers;
using eLearning.WebApp.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();

// Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Read backend URL from config
var backendUrl = builder.Configuration["ApiUrls:BackendUrl"];

// Register HTTP clients using helper method
builder.Services.AddHttpClient<OrderClientService>(client =>
{
    client.BaseAddress = new Uri(backendUrl!);
});

builder.Services.AddHttpClient<UserClientService>(client =>
{
    client.BaseAddress = new Uri(backendUrl!);
});

builder.Services.AddHttpClient<PaymentClientService>(client =>
{
    client.BaseAddress = new Uri(backendUrl!);
});

//builder.Services.AddBackendHttpClient<CourseClientService>(builder.Configuration);
//builder.Services.AddBackendHttpClient<OrderClientService>(builder.Configuration);
//builder.Services.AddBackendHttpClient<PaymentClientService>(builder.Configuration);
//builder.Services.AddBackendHttpClient<UserClientService>(builder.Configuration);

builder.Services
    .AddScoped<ICourseService, CourseClientService>()
    .AddScoped<IOrderService, OrderClientService>()
    .AddScoped<IUserService, UserClientService>()
    .AddScoped<IPaymentService, PaymentClientService>();

builder.Services.AddScoped<CartService>();
builder.Services.AddBlazoredSessionStorage();

builder.Services.AddSingleton<AppSettingsService>();

await builder.Build().RunAsync();
