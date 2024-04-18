namespace Domain.Entities.Commands;

public interface IParkingClear
{ 
    int ParkingID { get; set; }
    string CarNumber { get; set; }
}