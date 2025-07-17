using Blazored.SessionStorage;
using eLearning.WebApp.Client.Helpers;
using eLearning.WebApp.Client.Services;
using eLearning.WebApp.Components;
using eLearning.WebApp.Components.Account;
using eLearning.WebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddAuthenticationStateSerialization();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();

//builder.Services.AddAuthentication(options =>
//    {
//        options.DefaultScheme = IdentityConstants.ApplicationScheme;
//        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
//    })
//    .AddIdentityCookies();
builder.Services.AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddSignInManager()
//    .AddDefaultTokenProviders();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => 
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddHttpClient();

builder.Services.AddHttpClient("BackendUrl", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiUrls:BackendUrl"]!);
});

// Read backend URL from config
var backendUrl = builder.Configuration["ApiUrls:BackendUrl"];

// Register HTTP clients using helper method
builder.Services.AddBackendHttpClient<CourseClientService>(builder.Configuration);
builder.Services.AddBackendHttpClient<OrderClientService>(builder.Configuration);
builder.Services.AddBackendHttpClient<PaymentClientService>(builder.Configuration);
builder.Services.AddBackendHttpClient<UserClientService>(builder.Configuration);

builder.Services.AddSingleton<AppSettingsService>();

builder.Services
    .AddScoped<ICourseService, CourseClientService>()
    .AddScoped<IOrderService, OrderClientService>()
    .AddScoped<IUserService, UserClientService>()
    .AddScoped<IPaymentService, PaymentClientService>();

builder.Services.AddScoped<CartService>();

List<string> urlList = builder.Configuration.GetSection("WebClients:Links").Get<List<string>>()!;
string[] clientUrls = urlList.Select(i => i.ToString()).ToArray();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins(clientUrls)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddBlazoredSessionStorage();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.UseCors("AllowAll");

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(eLearning.WebApp.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
