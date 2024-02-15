using Microsoft.EntityFrameworkCore;
using PruebaHotel.Application.Service;
using PruebaHotel.Controllers;
using PruebaHotel.Persistence.DataAccess;
using PruebaHotel.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// INYECCION DE SERVICIOS
builder.Services.AddScoped<HotelService>();
builder.Services.AddScoped<RoomService>();
builder.Services.AddScoped<ReservationService>();
builder.Services.AddScoped<GuestService>();
builder.Services.AddScoped<contactEmergencyService>();

//INYECCION DE REPOSITORIOS
builder.Services.AddScoped<HotelRepository>();
builder.Services.AddScoped<RoomRepository>();
builder.Services.AddScoped<ReservationRepository>();
builder.Services.AddScoped<GuestRepository>();
builder.Services.AddScoped<ContactEmergencyRepository>();

//INYECCION DEL CONTEXTO
builder.Services.AddScoped<MyContext>();


//builder.Services.AddScoped<HotelService>();
//builder.Services.AddSingleton<HotelService>();


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
