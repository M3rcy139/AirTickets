using AirTickets.Core.Models;

namespace AirTickets.Application.Interfaces
{
    public interface ISeatService
    {
        Task<List<Seat>> GetAircraftSeats(int aircraftId);
        Task<Seat> GetSeatInfo(int seatId, int flightId);
    }
}
