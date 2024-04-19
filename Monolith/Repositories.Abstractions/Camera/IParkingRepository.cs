using Domain.Entities;

namespace Services.Abstractions.New;

public interface IParkingRepository
{
    Task CarOnParkingAsync(ICarNumber carNumber, CancellationToken token);
    Task CarIncidentAsync(ICarNumber carNumber, CancellationToken token);
    Task CarLeaveParkingAsync(ICarNumber carNumber, CancellationToken token);
}