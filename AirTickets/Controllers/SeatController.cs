using Microsoft.AspNetCore.Mvc;
using AirTickets.Application.Interfaces.Services;
using AirTickets.Application.Dto.Response;

namespace AirTickets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet("get-aircraft-seats/{aircraftId}")]
        public async Task<IActionResult> GetAircraftSeats(int aircraftId)
        {
            try
            {
                var seats = await _seatService.GetAircraftSeats(aircraftId);

                return Ok(seats);
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

        [HttpGet("get-seat-info/{seatId}/{flightId}")]
        public async Task<IActionResult> GetSeatInfo(int seatId, int flightId)
        {
            try
            {
                var seat = await _seatService.GetSeatInfo(seatId, flightId);

                var seatAvailability = await _seatService.GetSeatAvailability(seatId, flightId);

                var response = new SeatInfoResponse
                (
                    seat.Id,
                    seat.Class,
                    seat.SeatNumber,
                    seat.Price,
                    seatAvailability.IsAvailable
                );

                return Ok(seat);
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
