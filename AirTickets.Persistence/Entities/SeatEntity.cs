namespace AirTickets.Persistence.Entities
{
    public class SeatEntity
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public int AircraftId { get; set; }
        public string Class { get; set; }
        public decimal Price { get; set; }

        public AircraftEntity Aircraft { get; set; }
        public List<SeatAvailabilityEntity> SeatAvailabilities { get; set; }
    }
}
