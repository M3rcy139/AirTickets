namespace AirTickets.Persistence.Entities
{
    public class CrewEntity
    {
        public int Id { get; set; }
        public List<CrewMemberEntity> Members { get; set; }
    }
}
