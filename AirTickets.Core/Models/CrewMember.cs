namespace AirTickets.Core.Models
{
    public class CrewMember
    {
        public int Id { get; set; }            
        public string Name { get; set; }       
        public string Position { get; set; }  
        public int CrewId { get; set; }

        public Crew Crew { get; set; }
    }

}
