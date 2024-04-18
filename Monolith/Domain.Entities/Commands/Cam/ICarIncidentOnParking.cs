namespace Domain.Entities.Commands.Cam;

public interface ICarIncidentOnParking
{
    int ParkingID { get; set; }
    string CarNumber { get; set; }
}