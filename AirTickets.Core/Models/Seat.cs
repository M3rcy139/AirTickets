
namespace AirTickets.Core.Models
{
    public class Seat
    {
        public int Id { get; set; }              
        public string SeatNumber { get; set; }
        public int FlightId { get; set; }
        public string Class { get; set; }         
        public bool IsAvailable { get; set; }     

        public Flight Flight { get; set; }
    }
}
