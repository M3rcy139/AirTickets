using AirTickets.Application.Interfaces.Repositories;
using AirTickets.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AirTickets.Persistence
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services
                , IConfiguration configuration)
        {
            services.AddDbContext<AirTicketsDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(AirTicketsDbContext)));
            });

            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<ISupportRepository, SupportRepository>();

            return services;
        }
    }
}
