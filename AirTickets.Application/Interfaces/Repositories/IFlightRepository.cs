using AirTickets.Core.Models;


namespace AirTickets.Application.Interfaces.Repositories
{
    public interface IFlightRepository
    {
        Task<List<Flight>> GetAllFlights();
        Task<Flight> GetFlightDetails(int flightId);
    }
}
