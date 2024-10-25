using AirTickets.Core.Models;

namespace AirTickets.Application.Dto.Response
{
    public record FlightResponse
    (
        string RouteName,
        string AircraftModel,
        int AircraftId,
        DateTime DepartureTime,
        Crew Crew,
        decimal EconomyClasPrice,
        decimal BuisnessClassPrice

    );
}
