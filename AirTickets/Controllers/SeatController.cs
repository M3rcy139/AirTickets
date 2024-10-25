using Microsoft.AspNetCore.Mvc;
using AirTickets.Application.Interfaces;

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
            var seats = await _seatService.GetAircraftSeats(aircraftId);

            return Ok();
        }

        [HttpGet("get-seat-info/{seatId}/{flightId}")]
        public async Task<IActionResult> GetSeatInfo(int seatId, int flightId)
        {
            var seat = await _seatService.GetSeatInfo(seatId, flightId);

            return Ok();
        }
    }
}
