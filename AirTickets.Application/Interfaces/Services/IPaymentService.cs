using AirTickets.Core.Models;

namespace AirTickets.Application.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<Payment> ProcessPayment(User user, decimal amountPaid, string paymentType, List<int> seatIds, int flightId);
        Task<List<Ticket>> GetTickets(Guid paymentId);
    }
}
