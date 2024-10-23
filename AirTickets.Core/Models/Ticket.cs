namespace AirTickets.Core.Models
{
    public class Ticket
    {
        public int Id { get; set; }                   
        public string PassengerName { get; set; }
        public int FlightId { get; set; }
        public int SeatId { get; set; }
        public decimal Price { get; set; }          
        public DateTime PurchaseDate { get; set; } 

        public Flight Flight { get; set; } 
        public Seat Seat { get; set; }     
    }

}
