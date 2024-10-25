using AirTickets.Core.Models;
using AirTickets.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace AirTickets.Persistence
{
    public class AirTicketsDbContext(DbContextOptions <AirTicketsDbContext> options) : DbContext(options)
    {
        public DbSet<FlightEntity> Flights { get; set; }
        public DbSet<SeatEntity> Seats { get; set; }
        public DbSet<SeatAvailability> SeatAvailabilities { get; set; }
        public DbSet<AircraftEntity> Aircrafts { get; set; }
        public DbSet<CrewEntity> Crews { get; set; }
        public DbSet<CrewMemberEntity> CrewMembers { get; set; }
        public DbSet<TicketEntity> Tickets { get; set; }
        public DbSet<PaymentEntity> Payments { get; set; }
        public DbSet<IssueReportEntity> TerminalIssues { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
