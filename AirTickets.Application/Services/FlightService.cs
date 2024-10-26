using AirTickets.Application.Interfaces.Services;
using AirTickets.Core.Models;
using AirTickets.Application.Interfaces.Repositories;

namespace AirTickets.Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<List<Flight>> GetAllFlights()
        {
            var flights = await _flightRepository.GetAllFlights();

            return flights;
        }

        public async Task<Flight> GetFlightDetails(int flightId)
        {
            var flightDetail = await _flightRepository.GetFlightDetails(flightId);

            return flightDetail;
        }
    }
}
