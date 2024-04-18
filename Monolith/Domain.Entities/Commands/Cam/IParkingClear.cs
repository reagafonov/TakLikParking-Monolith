namespace Domain.Entities.Commands.Cam;

public interface IParkingClear
{ 
    int ParkingID { get; set; }
    string CarNumber { get; set; }
}