namespace Domain.Entities.Commands;

public interface ICarIncidentOnParking
{
    int ParkingID { get; set; }
    string CarNumber { get; set; }
}