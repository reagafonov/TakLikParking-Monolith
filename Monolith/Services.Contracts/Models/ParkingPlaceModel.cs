namespace Services.Contracts.Models;

public class ParkingPlaceModel
{
    public Guid Id { get; set; }

    
    public int Number { get; set; }
    
    public ParkingPlaceStatusEnumModel Status { get; set; }
    
    public bool IsAvailable { get; set; }
    
    public decimal Cost { get; set; }
    
    public int ParkingId { get; set; }
}