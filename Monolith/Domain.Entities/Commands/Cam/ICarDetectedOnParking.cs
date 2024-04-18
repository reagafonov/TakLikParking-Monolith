namespace Domain.Entities.Commands;

public interface ICarDetectedOnParking
{
    int ParkingID { get; set; }

    string CarNumber { get; set; }
}