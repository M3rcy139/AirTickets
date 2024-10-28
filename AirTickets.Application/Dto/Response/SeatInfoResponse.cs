namespace AirTickets.Application.Dto.Response
{
    public record SeatInfoResponse
    (
        int Id,
        string Class,
        int SeatNumber,
        decimal Price,
        bool IsAvailable
    );
}
