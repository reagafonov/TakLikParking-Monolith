using Domain.Entities.Commands.Cam;

namespace Services.Abstractions.New;

/// <summary>
/// фильтр сообщений
/// </summary>
public interface IAggregatorService
{
    Task OnCarDetectedOnParkingAsync(ICarDetectedOnParking carDetectedOnParking, CancellationToken token);
    Task OnCarIncidentOnParkingAsync(ICarIncidentOnParking carIncidentOnParking, CancellationToken token);
    Task OnParkingClearAsync(IParkingClear parkingClear, CancellationToken token);
}