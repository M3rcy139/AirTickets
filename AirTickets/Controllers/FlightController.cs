using Microsoft.AspNetCore.Mvc;
using AirTickets.Application.Dto.Response;
using Microsoft.EntityFrameworkCore;
using AirTickets.Application.Interfaces.Services;

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
            try
            {
                var flights = await _flightService.GetAllFlights();

                var response = flights.Select(f => f).ToList();

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpGet("{flightId}")]
        public async Task<IActionResult> GetFlightDetails(int flightId)
        {
            try
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
            catch (ArgumentException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }
    }
}

