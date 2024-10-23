namespace AirTickets.Persistence.Entities
{
    public class AircraftEntity
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int TotalEconomySeats { get; set; }
        public int TotalBusinessSeats { get; set; }
    }
}
