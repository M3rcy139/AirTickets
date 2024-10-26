using AirTickets.Core.Models;

namespace AirTickets.Application.Interfaces.Services
{
    public interface IFlightService
    {
        Task<List<Flight>> GetAllFlights();
        Task<Flight> GetFlightDetails(int flightId);
    }
}
