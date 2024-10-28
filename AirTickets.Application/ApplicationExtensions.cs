using AirTickets.Application.Interfaces.Services;
using AirTickets.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AirTickets.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<ISeatService, SeatService>();

            return services;
        }
    }
}
