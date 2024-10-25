using AirTickets.Persistence.Interfaces;
using AirTickets.Application.Interfaces;
using AirTickets.Core.Models;

namespace AirTickets.Application.Services
{
    public class SeatService : ISeatService
    {
        private ISeatRepository _seatRepository;

        public SeatService(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<List<Seat>> GetAircraftSeats(int aircraftId)
        {
            var seats = await _seatRepository.GetAircraftSeats(aircraftId);

            return seats;
        }

        public async Task<Seat> GetSeatInfo(int seatId, int flightId)
        {
            var seat = await _seatRepository.GetSeatInfo(seatId, flightId);

            return seat;
        }
    }
}
