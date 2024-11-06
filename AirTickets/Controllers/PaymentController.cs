using AirTickets.Application.Interfaces.Services;
using AirTickets.Core.Models;
using Microsoft.AspNetCore.Mvc;
using AirTickets.Application.Dto.Request;
using AirTickets.Application.Dto.Response;

namespace AirTickets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost("pay")]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest paymentRequest, ISeatService seatService,
            IPaymentService paymentService)
        {
            try
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Name = paymentRequest.Name,
                    Surname = paymentRequest.Surname,
                    Email = paymentRequest.Email,
                };

                var payment = await paymentService.ProcessPayment
                    (user, paymentRequest.AmountPaid, paymentRequest.PaymentType, paymentRequest.SeatIds,
                        paymentRequest.FlightId);

                var response = new PaymentResponse
                (
                    payment.Id,
                    payment.SeatIds,
                    payment.PaymentType,
                    payment.Amount,
                    payment.ChangeGiven,
                    payment.PaymentTime

                );

                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { error = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpGet("get-tickets/ticket")]
        public async Task<IActionResult> GetTickets(Guid paymentId, IPaymentService paymentService)
        {
            try
            {
                var tickets = await paymentService.GetTickets(paymentId);

                var response = tickets.Select(ticket => new TicketResponse
                (
                    ticket.RouteName,
                    ticket.AircraftModel,
                    ticket.Class,
                    ticket.SeatNumber,
                    ticket.Price,
                    ticket.UserName,
                    ticket.UserSurname,
                    ticket.DepartureDateTime,
                    ticket.ArrivalDateTime
                )).ToList();

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }
    }
}
