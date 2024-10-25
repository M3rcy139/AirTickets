using AirTickets.Core.Models;


namespace AirTickets.Persistence.Interfaces
{
    public interface IFlightRepository
    {
        Task<List<Flight>> GetAllFlights();
        Task<Flight> GetFlightDetails(int flightId);
    }
}
