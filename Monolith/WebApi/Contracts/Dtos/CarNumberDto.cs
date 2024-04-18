using Domain.Entities.New;

namespace WebApi.Contracts.Dtos;

public class CarNumberDto:ICarNumber
{
    public string Number { get; set; }
}