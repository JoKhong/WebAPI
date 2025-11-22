using CitiesManager.Core.Domain.RepositoryContracts;
using CitiesManager.Core.ServiceContracts;
using CitiesManager.Core.Services;
using CitiesManager.Infrastructure.Repositories;
using CitiesManager.WebAPI.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>
    (options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });


//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICitiesRepository, CitiesRepository>();

builder.Services.AddScoped<ICityGettersServices, CityGetterServices>();
builder.Services.AddScoped<ICityAdderService, CityAdderService>();
builder.Services.AddScoped<ICityUpdateService, CityUpdateService>();
builder.Services.AddScoped<ICityDeleterService, CityDeleterService>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHsts();
app.UseHttpsRedirection();

app.UseSwagger(); //Create endpoint for swagger.json
app.UseSwaggerUI(); //Create swagger UI for testing

app.UseAuthorization();

app.MapControllers();

app.Run();
