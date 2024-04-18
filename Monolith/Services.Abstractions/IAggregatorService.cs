using Domain.Entities.Commands;

namespace Services.Abstractions;

/// <summary>
/// фильтр сообщений
/// </summary>
public interface IAggregatorService
{
    Task OnCarDetectedOnParkingAsync(ICarDetectedOnParking carDetectedOnParking, CancellationToken token);
    Task OnCarIncidentOnParkingAsync(ICarIncidentOnParking carIncidentOnParking, CancellationToken token);
    Task OnParkingClearAsync(IParkingClear parkingClear, CancellationToken token);
}