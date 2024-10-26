using AirTickets.Core.Models;

namespace AirTickets.Application.Interfaces.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment> ProcessPayment(User user, decimal amountPaid, string paymentType, int seatId, int seanceId);
        Task<Ticket> GetTicket(Guid paymentId);
    }
}
