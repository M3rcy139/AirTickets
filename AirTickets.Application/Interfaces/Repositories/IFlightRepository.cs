using AirTickets.Core.Models;


namespace AirTickets.Application.Interfaces.Repositories
{
    public interface IFlightRepository
    {
        Task<List<Flight>> GetAllFlights();
        Task<Flight> GetFlightDetails(int flightId);
        Task<List<CrewMember>> GetCrewMemberships(int crewId);
        Task<Aircraft> GetAircraftDetails(int aircraftId);
    }
}
