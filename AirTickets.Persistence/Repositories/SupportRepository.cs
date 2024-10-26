using AirTickets.Application.Interfaces.Repositories;
using AirTickets.Persistence.Entities;
using AutoMapper;

namespace AirTickets.Persistence.Repositories
{
    public class SupportRepository : ISupportRepository
    {
        private readonly AirTicketsDbContext _context;
        private IMapper _mapper;
        public SupportRepository(AirTicketsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task ReportIssue(string message)
        {
            var issueReportEntity = new IssueReportEntity()
            {
                Message = message,
                MessageTime = DateTime.UtcNow,
            };
            await _context.IssueReports.AddAsync(issueReportEntity);
            await _context.SaveChangesAsync();
        }
    }
}
