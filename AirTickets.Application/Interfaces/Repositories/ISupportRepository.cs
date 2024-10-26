namespace AirTickets.Application.Interfaces.Repositories
{
    public interface ISupportRepository
    {
        Task ReportIssue(string message);
    }
}
