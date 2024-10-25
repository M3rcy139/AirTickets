using AirTickets.Core.Models;

namespace AirTickets.Persistence.Interfaces
{
    public interface ISeatRepository
    {
        Task<List<Seat>> GetAircraftSeats(int aircraftId);
        Task<Seat> GetSeatInfo(int seatId, int flightId);
    }
}
