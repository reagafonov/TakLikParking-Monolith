namespace Domain.Entities;

[Flags]
public enum MessageType
{
    None = 0,
    Parking = 1,
    // Human = 1<<1,
    Leave = 1<<2,
    Incident = 1<<3
}