
namespace AirTickets.Core.Models
{
    public class Seat
    {
        public int Id { get; set; }              
        public string SeatNumber { get; set; }
        public int AircraftId { get; set; }
        public string Class { get; set; }

        public Aircraft Aircraft { get; set; }        
        public List<SeatAvailability> SeatAvailabilities { get; set; }
    }
}
