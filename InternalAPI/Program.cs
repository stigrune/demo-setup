using API;
using API.External.Products;
using API.Internal.Weather;
using Core.Database;
using Core.Integrations;
using Core.Products;
using Infrastructure.DummyIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(Constants.External, new OpenApiInfo { Title = "Demo API", Version = "v1" });
    c.SwaggerDoc(Constants.Internal, new OpenApiInfo { Title = "Demo Internal API", Version = "v1" });

    c.DocInclusionPredicate((docName, apiDesc) =>
    {
        if (docName == Constants.External)
        {
            // Exclude internal
            return !apiDesc.RelativePath!.Contains(Constants.Internal);
        }
        if (docName == Constants.Internal)
        {
            // Include internal
            return apiDesc.RelativePath!.Contains(Constants.Internal); //We can probably use a custom attribute if we want to be more explicit about this.
        }
        return false;
    });
});

// Get a database path for the Sqlite database.
var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
var dbPath = Path.Join(path, "demo.db");
builder.Services.AddDbContext<DemoContext>(o => o.UseSqlite($"Data Source={dbPath}"));

// Register services.
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddKeyedTransient<IIntegrationClient, ProtoClient>("proto"); // Do not use magic strings, just for demo.
builder.Services.AddKeyedTransient<IIntegrationClient, DummyClient>("dummy"); // Do not use magic strings, just for demo.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "{documentName}/OpenAPI.json";
    });

    // External API Swagger UI
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/v1/OpenAPI.json", "Demo API V1");
        c.RoutePrefix = "swagger";
    });

    // Internal API Swagger UI
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/v1/OpenAPI.json", "Demo Internal API V1");
        c.RoutePrefix = $"{Constants.Internal}/swagger";
    });
}

app.UseHttpsRedirection();

app.RegisterWeatherEndpoints();
app.RegisterProductsEndpoints();

app.Run();

public partial class Program { } // Needed for integration testing