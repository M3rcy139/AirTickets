namespace AirTickets.Persistence.Entities
{
    public class SeatAvailabilityEntity
    {
        public Guid Id { get; set; }
        public int SeatId { get; set; }
        public int FlightId { get; set; }
        public bool IsAvailable { get; set; }
        public Guid PaymentId { get; set; }

        public PaymentEntity Payment { get; set; }
        public FlightEntity Flight { get; set; }
        public SeatEntity Seat { get; set; }
    }
}
