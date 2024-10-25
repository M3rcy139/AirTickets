using AirTickets.Core.Models;
using AirTickets.Persistence.Interfaces;

namespace AirTickets.Persistence.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        public Task<List<Seat>> GetAircraftSeats(int aircraftId)
        {
            throw new NotImplementedException();
        }

        public Task<Seat> GetSeatInfo(int seatId, int flightId)
        {
            throw new NotImplementedException();
        }
    }
}
