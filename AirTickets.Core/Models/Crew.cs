namespace AirTickets.Core.Models
{
    public class Crew
    {
        public int Id { get; set; }                
        public List<CrewMember> Members { get; set; }
    }

}
