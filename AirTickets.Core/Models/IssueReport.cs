
namespace AirTickets.Core.Models
{
    public class IssueReport
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime MessageTime { get; set; }
    }
}
