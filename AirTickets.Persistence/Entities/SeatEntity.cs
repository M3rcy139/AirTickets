namespace AirTickets.Persistence.Entities
{
    public class SeatEntity
    {
        public int Id { get; set; }
        public string SeatNumber { get; set; }
        public int FlightId { get; set; }
        public string Class { get; set; }
        public bool IsAvailable { get; set; }
        
        public FlightEntity Flight { get; set; }
    }
}
