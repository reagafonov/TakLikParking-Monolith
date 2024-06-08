using Domain.Entities;
using Domain.Entities.Commands.Cam;
using Services.Contracts.Models;
using INotificationMessage = Domain.Entities.INotificationMessage;

namespace Services.Implementation;

public class MessageFactory:IMessageFactory
{
    public IMessageOptions CreateMessageOption(MessageType messageType, NotifyOptions options)
    {
        return new MessageOptionsModel()
        {
            NotifyOptions = options
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