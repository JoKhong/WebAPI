using Asp.Versioning;
using CitiesManager.Core.Domain.RepositoryContracts;
using CitiesManager.Core.ServiceContracts;
using CitiesManager.Core.Services;
using CitiesManager.Infrastructure.Repositories;
using CitiesManager.WebAPI.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => { 
    options.Filters.Add(new ProducesAttribute("application/json"));
    options.Filters.Add(new ConsumesAttribute("application/json"));
})
    .AddXmlDataContractSerializerFormatters();

builder.Services.AddApiVersioning( config => {

    config.DefaultApiVersion = new ApiVersion(1.0);
    config.AssumeDefaultVersionWhenUnspecified = true;

    config.ApiVersionReader = new UrlSegmentApiVersionReader(); //Reads version number from request url at "apiVersion" constraint

    //config.ApiVersionReader = new HeaderApiVersionReader();
    //config.ApiVersionReader = new QueryStringApiVersionReader(); // query string is 'api-version'

});

//builder.Services.AddVersionedApiExplorer(options =>
//{
//    options.GroupNameFormat = "'v'VVV";
//    options.SubstituteApiVersionInUrl = true;
//});

builder.Services.AddDbContext<ApplicationDbContext>
    (options => {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });


//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options => {
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "api.xml"));
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "Cities Web API",
        Version = "1.0"
    });

    //options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo()
    //{
    //    Title = "Cities Web API",
    //    Version = "2.0"
    //});
});

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
app.UseSwaggerUI( options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "1.0");
}); //Create swagger UI for testing

app.UseAuthorization();

app.MapControllers();

app.Run();
