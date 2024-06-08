using Domain.Entities;
using Domain.Entities.Commands;
using Domain.Entities.Commands.Cam;
using Services.Contracts.Models;
using INotificationMessage = Domain.Entities.INotificationMessage;

namespace Services.Implementation;

public class ServiceFactory:IServiceFactory
{
    public ICarStatus CreateCarStatus<TCarKey>(ICar<TCarKey>? car) where TCarKey : struct
    {
        throw new NotImplementedException();
    }

    public IMessageOptions CreateMessageOption(MessageType messageType, NotifyOptions options)
    {
        return new MessageOptionsModel()
        {
            NotifyOptions = options
        };
    }

    public ICarNumber CreateCarNumber(string? carNumber)
    {
        return new CarNumberModel()
        {
            Number = carNumber
        };
    }

    public INotificationMessage CreateMessage(ICarDetectedOnParking carDetectedOnParking)
    {
        return new NotificationMessageModel()
        {
            MessageText = $"Машина с номером {carDetectedOnParking.CarNumber} видна на парковке"
        };
    }

    public INotificationMessage CreateMessage(ICarIncidentOnParking carIncidentOnParking)
    {
        return new NotificationMessageModel()
        {
            MessageText = $"С машиной с номером {carIncidentOnParking.CarNumber} что-то произошло"
        };
    }

    public INotificationMessage CreateMessage(IParkingClear carDetectedOnParking)
    {
        return new NotificationMessageModel()
        {
            MessageText = $"Машина с номером {carDetectedOnParking.CarNumber} больше н видна на парковке"
        };
    }
}