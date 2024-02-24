using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaHotel.Application.Service;
using PruebaHotel.Domain.Interface;

namespace PruebaHotel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Configure services for the application
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            //services.AddScoped<HotelService>();
            //services.AddTransient<HotelService>();
            services.AddSingleton<IHotelService, HotelService>();
            //services.AddControllers();
            //services.AddScoped<RoomService>();
            services.AddTransient<RoomService>();
            //services.AddSingleton<RoomService>();
            //services.AddControllers();
            //services.AddScoped<ReservationService>();
            services.AddTransient<ReservationService>();
            //services.AddSingleton<ReservationService>();
            //services.AddControllers();
            //services.AddScoped<GuestService>();
            services.AddTransient<GuestService>();
            //services.AddSingleton<GuestService>();
            //services.AddControllers();
            //services.AddScoped<contactEmergencyService>();
            services.AddTransient<contactEmergencyService>();
            //services.AddSingleton<contactEmergencyService>();
            //services.AddControllers();
        }

        // Configure the application's request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            //var hotelService = app.ApplicationServices.GetService<HotelService>();
            //var roomService = app.ApplicationServices.GetService<RoomService>();
            //var reservationService = app.ApplicationServices.GetService<ReservationService>();
            //var guestService = app.ApplicationServices.GetService<GuestService>();
            //var contactEmergencyService = app.ApplicationServices.GetService<contactEmergencyService>();
        }
        
    }
}
