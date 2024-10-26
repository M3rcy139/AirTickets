
namespace AirTickets.Core.Models
{
    public class Seat
    {
        public int Id { get; set; }              
        public int SeatNumber { get; set; }
        public int AircraftId { get; set; }
        public string Class { get; set; }
        public decimal Price { get; set; }

        public Aircraft Aircraft { get; set; }        
        public List<SeatAvailability> SeatAvailabilities { get; set; }
    }
}
