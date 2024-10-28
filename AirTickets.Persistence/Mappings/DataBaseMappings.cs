using AirTickets.Persistence.Entities;
using AirTickets.Core.Models;
using AutoMapper;

namespace AirTickets.Persistence.Mappings
{
    public class DataBaseMappings : Profile
    {
        public DataBaseMappings()
        {
            CreateMap<AircraftEntity, Aircraft>();
            CreateMap<PaymentEntity, Payment>();
            CreateMap<CrewEntity, Crew>();
            CreateMap<SeatEntity, Seat>();
            CreateMap<TicketEntity, Ticket>();
            CreateMap<UserEntity, User>();
            CreateMap<IssueReportEntity, IssueReport>();
            CreateMap<CrewMemberEntity, CrewMember>();
            CreateMap<FlightEntity, Flight>(); 
            CreateMap<SeatAvailabilityEntity, SeatAvailability>();
        }
    }
}
