namespace AirTickets.Application.Dto.Response
{
    public record PaymentResponse
    (
        Guid Id,
        List<int> SeatIds,
        string PaymentType,
        decimal Amount,
        decimal? ChangeGiven,
        DateTime PaymentTime
    );
}
