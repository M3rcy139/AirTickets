namespace AirTickets.Persistence.Entities
{
    public class SeatEntity
    {
        public int Id { get; set; }
        public string SeatNumber { get; set; }
        public int AircraftId { get; set; }
        public string Class { get; set; }

        public AircraftEntity Aircraft { get; set; }
        public List<SeatAvailabilityEntity> SeatAvailabilities { get; set; }
    }
}
