namespace AirTickets.Persistence.Entities
{
    public class CrewMemberEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int CrewId { get; set; }

        public CrewEntity Crew { get; set; }
    }
}
