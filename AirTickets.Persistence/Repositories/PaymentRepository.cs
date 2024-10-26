using AirTickets.Core.Models;
using AirTickets.Application.Interfaces.Repositories;
using AirTickets.Application.Interfaces.Services;
using AutoMapper;
using AirTickets.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirTickets.Persistence.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AirTicketsDbContext _context;
        private IMapper _mapper;
        private ISeatService _seatService;
        public PaymentRepository(AirTicketsDbContext context, IMapper mapper, ISeatService seatService)
        {
            _context = context;
            _mapper = mapper;
            _seatService = seatService;
        }
        public async Task<Payment> ProcessPayment(User user, decimal amountPaid, string paymentType, int seatId, int seanceId)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
            };

            var totalCost = _seatService.GetSeatPrice(seatId).Result;

            if (totalCost > amountPaid)
                throw new InvalidOperationException("Недостаточно средств");

            decimal changeGiven = amountPaid - totalCost;

            var paymentEntity = new PaymentEntity
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                SeatId = seatId,
                Amount = amountPaid,
                PaymentType = paymentType,
                PaymentTime = DateTime.UtcNow,
                ChangeGiven = changeGiven
            };

            var ticketEntity = await GetInfoForTicket(user, seatId, seanceId, paymentEntity.Id);

            await _context.Users.AddAsync(userEntity);
            await _context.Payments.AddAsync(paymentEntity);
            await _context.Tickets.AddAsync(ticketEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Payment>(paymentEntity);
        }

        public async Task<TicketEntity> GetInfoForTicket(User user, int seatId, int flightId, Guid paymentId)
        {
            var seat = await _context.Seats
                .FirstOrDefaultAsync(s => s.Id == seatId)
                ?? throw new InvalidOperationException($"Данное место ({seatId}) не существует");

            var flight = await _context.Flights
                .FirstOrDefaultAsync(f => f.Id == flightId)
                ?? throw new InvalidOperationException($"Данный рейс ({flightId}) не существует");

            var aircraft = await _context.Aircrafts
                .FirstOrDefaultAsync(a => a.Id == flight.AircraftId)
                ?? throw new InvalidOperationException($"Данный самолет ({flight.AircraftId}) не существует");

            var ticketEntity = new TicketEntity
            {
                Id = Guid.NewGuid(),
                SeatId = seatId,
                RouteName = flight.RouteName,
                AircraftModel = aircraft.Model,
                DepartureDateTime = flight.DepartureDateTime,
                ArrivalDateTime = flight.ArrivalDateTime,
                Class = seat.Class,
                SeatNumber = seat.SeatNumber,
                UserName = user.Name,
                UserSurname = user.Surname,
                Price = seat.Price,
                PaymentId = paymentId
            };

            return ticketEntity;
        }

        public async Task<Ticket> GetTicket(Guid paymentId)
        {
            var ticket = await _context.Tickets
                .Include(t => t.Seat)
                .Include(t => t.Payment)
                .FirstOrDefaultAsync(t => t.PaymentId == paymentId)
                ?? throw new ArgumentException("Билет найти не удалось");

            return _mapper.Map<Ticket>(ticket);
        }
    }
}
