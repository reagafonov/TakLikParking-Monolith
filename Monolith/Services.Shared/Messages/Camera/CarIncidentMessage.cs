using Domain.Entities.Commands.Cam;

namespace Services.Shared.Messages.Camera;

public class CarIncidentMessage:ICarIncidentOnParking
{ 
    public string CarNumber { get; set; }
}