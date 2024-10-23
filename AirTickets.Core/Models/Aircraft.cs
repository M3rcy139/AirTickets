namespace AirTickets.Core.Models
{
    public class Aircraft
    {
        public int Id { get; set; }              
        public string Model { get; set; }           
        public int TotalEconomySeats { get; set; }   
        public int TotalBusinessSeats { get; set; }  
    }

}
