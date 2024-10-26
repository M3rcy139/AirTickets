using AirTickets.Core.Models;
using AirTickets.Application.Interfaces.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AirTickets.Persistence.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly AirTicketsDbContext _context;
        private readonly IMapper _mapper;

        public FlightRepository(AirTicketsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Flight>> GetAllFlights()
        {
            var flights = await _context.Flights
                .Select(f => f)
                .ToListAsync();

            if (!flights.Any())
                throw new ArgumentException("Ни одного рейса не найдено");

            return _mapper.Map<List<Flight>>(flights);
        }

        public async Task<Flight> GetFlightDetails(int flightId)
        {
            var flight = await _context.Flights
                .Include(f => f.Aircraft)
                .Include(f => f.Crew)
                .Include(f => f.SeatAvailabilities)
                .FirstOrDefaultAsync(f => f.Id == flightId) ?? throw new ArgumentException("Данное место не существует");

            return _mapper.Map<Flight>(flight);
        }
    }
}
