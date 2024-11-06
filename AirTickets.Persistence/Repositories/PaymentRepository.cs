using AirTickets.Core.Models;
using AirTickets.Application.Interfaces.Repositories;
using AirTickets.Application.Interfaces.Services;
using AutoMapper;
using AirTickets.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
        public async Task<Payment> ProcessPayment(User user, decimal amountPaid, string paymentType, List<int> seatIds, int seanceId)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
            };

            decimal totalCost = 0;
            foreach (var seatId in seatIds)
            {
                totalCost += await _seatService.GetSeatPrice(seatId);
            }

            if (totalCost > amountPaid)
                throw new InvalidOperationException("Недостаточно средств");

            decimal changeGiven = amountPaid - totalCost;

            var ticketEntities = new List<TicketEntity>();


            var paymentEntity = new PaymentEntity
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                SeatIds = seatIds,
                Amount = amountPaid,
                PaymentType = paymentType,
                PaymentTime = DateTime.UtcNow,
                ChangeGiven = changeGiven 
            };

            // Генерируем платеж и билет для каждого выбранного места
            foreach (var seatId in seatIds)
            { 
                var ticketEntity = await GetInfoForTicket(user, seatId, seanceId, paymentEntity.Id);

                ticketEntities.Add(ticketEntity);
            }

            await _context.Users.AddAsync(userEntity);
            await _context.Payments.AddAsync(paymentEntity);
            await _context.Tickets.AddRangeAsync(ticketEntities);
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

        public async Task<List<Ticket>> GetTickets(Guid paymentId)
        {
            var ticket = await _context.Tickets
                .Include(t => t.Seat)
                .Include(t => t.Payment)
                .Where(t => t.PaymentId == paymentId)
                .ToListAsync()
                ?? throw new ArgumentException("Билет найти не удалось");

            return _mapper.Map<List<Ticket>>(ticket);
        }
    }
}
