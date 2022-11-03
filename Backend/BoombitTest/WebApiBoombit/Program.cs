using Domain.Domain.Interfaces;
using Domain.Domain.Interfaces.Services;
using Domain.Entities;
using Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Service.Main;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApiContext>(
    options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("sqlConnection"),
            x => x.MigrationsAssembly("WebApiBoombit")));

builder.Services.AddTransient<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IUserService, UserService>(); 

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true)
               .AllowCredentials());
app.Run();

