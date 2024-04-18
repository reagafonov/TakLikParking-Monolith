using Domain.Entities.New;

namespace WebApi.Contracts.Dtos;

public class CarNumberModel:ICarNumber
{
    public string Number { get; set; }
}