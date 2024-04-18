using Domain.Entities.New;

namespace Repositories.Implementations.New.Models;

public class CarNumberModel:ICarNumber
{
    public string Number { get; set; }
}