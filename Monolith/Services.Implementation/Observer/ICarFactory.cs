using Domain.Entities;
using Domain.Entities.Commands;

namespace Services.Implementation;

public interface ICarFactory 
{
    ICarStatus CreateCarStatus<TCarKey>(ICar<TCarKey>? car) where TCarKey : struct;
    ICarNumber CreateCarNumber(string? carNumber);
   
}