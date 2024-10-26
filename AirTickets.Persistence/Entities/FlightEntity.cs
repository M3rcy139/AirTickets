namespace AirTickets.Persistence.Entities
{
   public class FlightEntity
    {
        public int Id { get; set; }
        public string RouteName { get; set; }
        public int AircraftId { get; set; }
        public int CrewId { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public decimal EconomyClassPrice { get; set; }
        public decimal BusinessClassPrice { get; set; }
        
        public AircraftEntity Aircraft { get; set; }
        public CrewEntity Crew { get; set; }
        public List<SeatAvailabilityEntity> SeatAvailabilities { get; set; }
    }
}
