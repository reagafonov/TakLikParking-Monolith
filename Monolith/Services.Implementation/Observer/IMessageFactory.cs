using Domain.Entities;
using Domain.Entities.Commands.Cam;
using INotificationMessage = Domain.Entities.INotificationMessage;

namespace Services.Implementation;

public interface IMessageFactory
{
    IMessageOptions CreateMessageOption(MessageType messageType, NotifyOptions options);
    INotificationMessage CreateMessage(ICarDetectedOnParking carDetectedOnParking);
    INotificationMessage CreateMessage(ICarIncidentOnParking carIncidentOnParking);
    INotificationMessage CreateMessage(IParkingClear carDetectedOnParking);
}