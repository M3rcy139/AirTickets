
namespace AirTickets.Core.Models
{
    public class Flight
    {
        public int Id { get; set; }              
        public string FlightNumber { get; set; }
        public int AircraftId { get; set; }      
        public int CrewId { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public decimal EconomyClassPrice { get; set; } 
        public decimal BusinessClassPrice { get; set; } 
        
        public Aircraft Aircraft { get; set; }     
        public Crew Crew { get; set; }  
        public List<Seat> Seats { get; set; }
    }
}
