using Domain.Entities;
using Domain.Entities.Commands;
using Domain.Entities.New;

namespace Services.Implementation;

public interface IServiceFactory
{
    ICarStatus CreateCarStatus<TCarKey>(ICar<TCarKey>? car) where TCarKey : struct;
    IMessageOptions CreateMessageOption(MessageType messageType, NotifyOptions options);
    ICarNumber CreateCarNumber(string carNumber);
    INotificationMessageData CreateMessage(ICarDetectedOnParking carDetectedOnParking);
    INotificationMessageData CreateMessage(ICarIncidentOnParking carIncidentOnParking);
    INotificationMessageData CreateMessage(IParkingClear carDetectedOnParking);
}