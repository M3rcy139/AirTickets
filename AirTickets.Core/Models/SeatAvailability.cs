namespace AirTickets.Core.Models
{
    public class SeatAvailability
    {
        public Guid Id { get; set; }                 
        public int SeatId { get; set; }                         
        public int FlightId { get; set; }                       
        public bool IsAvailable { get; set; }          
        public Guid? PaymentId { get; set; }            
        
        public Payment Payment { get; set; }
        public Flight Flight { get; set; }
        public Seat Seat { get; set; }
    }
}
