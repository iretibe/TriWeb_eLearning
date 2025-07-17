using eLearning.Api;
using eLearning.Api.Hubs;
using eLearning.Application;
using eLearning.Domain.Entities;
using eLearning.Infrastructure;
using eLearning.Infrastructure.Data;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddDbContext<eLearningContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 12;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
})
.AddEntityFrameworkStores<eLearningContext>()
.AddDefaultTokenProviders();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

builder.Services.AddSignalR();

builder.Services.AddOpenApi();

builder.Services.Configure<FormOptions>(options =>
{
    //options.MultipartBodyLengthLimit = 5_368_709_120L; // 5GB
    options.MultipartBodyLengthLimit = 3_221_225_472; // 3 GB
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
    var seeder = new IdentitySeeder(roleManager);
    await seeder.SeedRolesAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapOpenApi();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(builder.Configuration["AppSettings:Folder"] + "/swagger/v1/swagger.json", "eLearning API");
    });
}

app.UseCors("AllowAll");
app.MapHub<CourseHub>("/hubs/course").RequireCors("AllowAll");

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads")),
    RequestPath = "/wwwroot/uploads"
});

app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads")),
    RequestPath = "/wwwroot/uploads"
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
