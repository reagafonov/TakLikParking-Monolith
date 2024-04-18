using Domain.Entities;

namespace Services.Contracts.Models;

public class CarNumberModel:ICarNumber
{
    public string Number { get; set; }
}