using AirTickets.Core.Models;

namespace AirTickets.Application.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<Payment> ProcessPayment(User user, decimal amountPaid, string paymentType, int seatId, int flightId);
        Task<Ticket> GetTicket(Guid paymentId);
    }
}
