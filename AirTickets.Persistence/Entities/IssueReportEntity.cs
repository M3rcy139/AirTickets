namespace AirTickets.Persistence.Entities
{
    public class IssueReportEntity
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime MessageTime { get; set; }
    }
}
