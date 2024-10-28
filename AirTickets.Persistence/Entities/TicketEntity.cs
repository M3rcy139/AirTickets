using AirTickets.Core.Models;

namespace AirTickets.Persistence.Entities
{
    public class TicketEntity
    {
        public Guid Id { get; set; }
        public int SeatId { get; set; }
        public string RouteName { get; set; }
        public string AircraftModel { get; set; }
        public int SeatNumber { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public string Class { get; set; }
        public decimal Price { get; set; }
        public Guid PaymentId { get; set; }


        public SeatEntity Seat { get; set; }
        public AircraftEntity Aircraft { get; set; }
        public PaymentEntity Payment { get; set; }
    }
}
