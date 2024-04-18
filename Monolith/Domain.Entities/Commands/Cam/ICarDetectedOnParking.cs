namespace Domain.Entities.Commands.Cam;

public interface ICarDetectedOnParking
{
    int ParkingID { get; set; }

    string CarNumber { get; set; }
}