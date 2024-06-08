using Domain.Entities;
using Domain.Entities.Commands.Cam;
using Services.Contracts.Models;
using INotificationMessage = Domain.Entities.INotificationMessage;

namespace Services.Implementation;

public class CarFactory:ICarFactory
{
    public ICarStatus CreateCarStatus<TCarKey>(ICar<TCarKey>? car) where TCarKey : struct
    {
        throw new NotImplementedException();
    }
    
    public ICarNumber CreateCarNumber(string? carNumber)
    {
        return new CarNumberModel()
        {
            Number = carNumber
        };
    }
}