using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using vehiclesAPI.Domain.Interfaces;
using vehiclesAPI.Infraestructure.DataAccess;
using vehiclesAPI.Infraestructure.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(c => c.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddScoped(typeof(IVehicleRepository), typeof(VehicleRepository));

builder.Services.AddControllers().AddJsonOptions(x =>
{
    // serialize enums as strings in api responses (e.g. Role)
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
}); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
