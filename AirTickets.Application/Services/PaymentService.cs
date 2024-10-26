using AirTickets.Application.Interfaces.Services;
using AirTickets.Core.Models;
using AirTickets.Application.Interfaces.Repositories;

namespace AirTickets.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ISeatService _seatService;
        public PaymentService(IPaymentRepository paymentRepository, ISeatService seatService)
        {
            _paymentRepository = paymentRepository;
            _seatService = seatService;
        }

        public async Task<Payment> ProcessPayment(User user, decimal amountPaid, string paymentType, int seatId, int flightId)
        {
            var payment = await _paymentRepository.ProcessPayment(user, amountPaid, paymentType, seatId, flightId);

            await _seatService.ChangeSeatStatus(seatId, flightId, false);

            return payment;
        }
        
        public async Task<Ticket> GetTicket(Guid paymentId)
        {
            var ticket = await _paymentRepository.GetTicket(paymentId);

            return ticket;
        }
    }
}
