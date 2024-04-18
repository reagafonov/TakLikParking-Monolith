using Domain.Entities.Commands.Cam;

namespace Services.Shared.Messages.Camera;

public class CarOnParkingMessage:ICarDetectedOnParking
{
    public string CarNumber { get; set; }
}