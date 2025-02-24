using Microsoft.Identity.Client;
using ProjectMap.WebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.Configure<RouteOptions>(o => o.LowercaseUrls = true);

var sqlConnectionString = builder.Configuration["SqlConnectionString"];

if (string.IsNullOrWhiteSpace(sqlConnectionString))
    throw new InvalidProgramException("Configuration variable SqlConnectionString not found");

builder.Services.AddTransient<IEnvironment2DRepository, Environment2DRepository>(o => new Environment2DRepository(sqlConnectionString));
builder.Services.AddTransient<IObject2DRepository, Object2DRepository>(o => new Object2DRepository(sqlConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.|
app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();