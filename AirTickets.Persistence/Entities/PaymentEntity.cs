using AirTickets.Core.Models;

namespace AirTickets.Persistence.Entities
{
    public class PaymentEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int SeatId { get; set; }
        public string PaymentType { get; set; }
        public decimal Amount { get; set; }
        public decimal? ChangeGiven { get; set; }
        public DateTime PaymentTime { get; set; }

        public UserEntity User { get; set; }

        public ICollection<SeatAvailabilityEntity> SeatAvailabilities { get; set; }
        public ICollection<TicketEntity> Tickets { get; set; }
    }
}
