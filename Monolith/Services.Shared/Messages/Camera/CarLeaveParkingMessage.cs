using Domain.Entities.Commands.Cam;

namespace Services.Shared.Messages.Camera;

public class CarLeaveParkingMessage:IParkingClear
{
    public string? CarNumber { get; set; }
}