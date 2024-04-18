using Domain.Entities;
using Domain.Entities.Commands;
using Domain.Entities.New;
using Services.Contracts.Models;
using WebApi.Contracts.Dtos;

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

    public ICarNumber CreateCarNumber(string carNumber)
    {
        return new CarNumberModel()
        {
            Number = carNumber
        };
    }

    public INotificationMessageData CreateMessage(ICarDetectedOnParking carDetectedOnParking)
    {
        return new NotificationMessageDataModel()
        {
            MessageText = $"Машина с номером {carDetectedOnParking.CarNumber} видна на парковке"
        };
    }

    public INotificationMessageData CreateMessage(ICarIncidentOnParking carIncidentOnParking)
    {
        return new NotificationMessageDataModel()
        {
            MessageText = $"С машиной с номером {carIncidentOnParking.CarNumber} что-то произошло"
        };
    }

    public INotificationMessageData CreateMessage(IParkingClear carDetectedOnParking)
    {
        return new NotificationMessageDataModel()
        {
            MessageText = $"Машина с номером {carDetectedOnParking.CarNumber} больше н видна на парковке"
        };
    }
}