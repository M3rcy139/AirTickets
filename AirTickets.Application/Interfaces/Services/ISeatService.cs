using AirTickets.Core.Models;

namespace AirTickets.Application.Interfaces.Services
{
    public interface ISeatService
    {
        Task<List<Seat>> GetAircraftSeats(int aircraftId);
        Task<Seat> GetSeatInfo(int seatId, int flightId);
        Task<SeatAvailability> GetSeatAvailability(int seatId, int flightId);
        Task<decimal> GetSeatPrice(int seatId);
        Task ChangeSeatStatus(int seatId, int flightId, bool isAvailable);
    }
}
