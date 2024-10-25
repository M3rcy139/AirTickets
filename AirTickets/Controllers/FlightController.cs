using Microsoft.AspNetCore.Mvc;
using AirTickets.Application.Dto.Response;
using Microsoft.EntityFrameworkCore;
using AirTickets.Application.Interfaces;

namespace AirTickets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet("get-all-flights")]
        public async Task<IActionResult> GetAllFlight()
        {
            var flights = await _flightService.GetAllFlights();

            var response = flights.Select(f => f).ToList();

            return Ok(response);
        }

        [HttpGet("{flightId}")]
        public async Task<IActionResult> GetFlightDetails(int flightId)
        {
            var flight = await _flightService.GetFlightDetails(flightId);

            var response = new FlightResponse
            (
                flight.RouteName,
                flight.Aircraft.Model,
                flight.Aircraft.Id,
                flight.DepartureDateTime,
                flight.Crew,
                flight.EconomyClassPrice,
                flight.BusinessClassPrice
            );

            return Ok(response);
        }
    }
}

