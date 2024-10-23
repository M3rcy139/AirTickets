namespace AirTickets.Persistence.Entities
{
    public class PaymentEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string PaymentMethod { get; set; }
        public int TicketId { get; set; }
        public decimal Amount { get; set; }
        public decimal Change { get; set; }
        public DateTime PaymentDate { get; set; }

        public TicketEntity Ticket { get; set; }
        public UserEntity User { get; set; }
    }
}
