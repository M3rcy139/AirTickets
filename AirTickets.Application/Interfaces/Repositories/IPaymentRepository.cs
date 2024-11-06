using AirTickets.Core.Models;

namespace AirTickets.Application.Interfaces.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment> ProcessPayment(User user, decimal amountPaid, string paymentType, List<int> seatIds, int seanceId);
        Task<List<Ticket>> GetTickets(Guid paymentId);
    }
}
