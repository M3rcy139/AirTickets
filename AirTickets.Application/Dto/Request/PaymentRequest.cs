
namespace AirTickets.Application.Dto.Request
{
    public record PaymentRequest
    (
        string Name,
        string Surname,
        string Email,
        string PaymentType,
        decimal AmountPaid,
        int SeatId,
        int FlightId
    );
}
