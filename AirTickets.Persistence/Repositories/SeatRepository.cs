using AirTickets.Core.Models;
using AirTickets.Application.Interfaces.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AirTickets.Persistence.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly AirTicketsDbContext _context;
        private readonly IMapper _mapper;

        public SeatRepository(AirTicketsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Seat>> GetAircraftSeats(int aircraftId)
        {
            var seats = await _context.Seats
                            .Where(s => s.AircraftId == aircraftId)
                            .ToListAsync();

            if (!seats.Any())
            {
                throw new ArgumentException("Мест для указанного самолета не найдено");
            }

            return _mapper.Map<List<Seat>>(seats);
        }

        public async Task<Seat> GetSeatInfo(int seatId, int flightId)
        {
            var seat = await _context.Seats
                            .FirstOrDefaultAsync(s => s.Id == seatId) ?? throw new ArgumentException("Данное место не существует");

            return _mapper.Map<Seat>(seat);
        }

        public async Task<SeatAvailability> GetSeatAvailability(int seatId, int flightId)
        {
            var seatAvailability = await _context.SeatAvailabilities
                    .FirstOrDefaultAsync(s => s.SeatId == seatId && s.FlightId == flightId)
                        ?? throw new ArgumentException("Данное место или рейс не существует");

            return _mapper.Map<SeatAvailability>(seatAvailability);
        }

        public async Task<decimal> GetSeatPrice(int seatId)
        {
            var price = await _context.Seats
                .Where(s => s.Id == seatId)
                .Select(s => s.Price)
                .FirstOrDefaultAsync();

            if (price == default)
                throw new InvalidOperationException("Цена для данного места не найдена или не была установлена");

            return price;
        }

        public async Task ChangeSeatStatus(int seatId, int flightId, bool isAvailable)
        {
            var seatAvailability = await _context.SeatAvailabilities
                           .Where(s => s.SeatId == seatId && s.FlightId == flightId)
                           .FirstOrDefaultAsync();

            if (seatAvailability == null)
                throw new ArgumentException("Место не найдено для указанного рейса");

            seatAvailability.IsAvailable = isAvailable;
            _context.SaveChanges();
        }
    }
}
