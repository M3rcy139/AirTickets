namespace AirTickets.Application.Dto.Response
{
    public record PaymentResponse
    (
        Guid Id,
        int SeatId,
        string PaymentType,
        decimal Amount,
        decimal? ChangeGiven,
        DateTime PaymentTime
    );
}
