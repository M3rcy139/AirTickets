namespace AirTickets.Persistence.Entities
{
    public class TicketEntity
    {
        public int Id { get; set; }
        public string PassengerName { get; set; }
        public int FlightId { get; set; }
        public int SeatId { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }

        public FlightEntity Flight { get; set; }
        public SeatEntity Seat { get; set; }
    }
}
