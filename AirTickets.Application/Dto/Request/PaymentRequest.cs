
namespace AirTickets.Application.Dto.Request
{
    public record PaymentRequest
    (
        string Name,
        string Surname,
        string Email,
        string PaymentType,
        decimal AmountPaid,
        List<int> SeatIds,
        int FlightId
    );
}
