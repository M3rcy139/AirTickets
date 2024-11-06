namespace AirTickets.Application.Dto.Response
{
    public record TicketResponse
    (
        string RouteName,
        string AircraftModel,
        string Class,
        int SeatNumber,
        decimal Price,
        string UserName,
        string UserSurname,
        DateTime DepartureDateTime,
        DateTime ArrivalDateTime
    );
}
