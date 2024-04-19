using Domain.Entities;

namespace WebApi.Contracts.Requests;

public class CarRequest
{
    public CarNumberRequest Number { get; set; }
    public NotifyOptions Parked { get; set; }
    public NotifyOptions Incident { get; set; }
    public NotifyOptions Leave { get; set; }
}