using AirTickets.Application.Interfaces.Repositories;
using AirTickets.Core.Models;
using AirTickets.Application.Interfaces.Services;

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

        public async Task<SeatAvailability> GetSeatAvailability(int seatId, int flightId)
        {
            var seatAvailability = await _seatRepository.GetSeatAvailability(seatId, flightId);

            return seatAvailability;
        }
        
        public async Task<decimal> GetSeatPrice(int seatId)
        {
            var price = await _seatRepository.GetSeatPrice(seatId);

            return price;
        }

        public async Task ChangeSeatStatus(int seatId, int flightId, bool isAvailable)
        {
            await _seatRepository.ChangeSeatStatus(seatId, flightId, isAvailable);
        }
    }
}
