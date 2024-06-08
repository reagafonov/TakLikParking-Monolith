using Domain.Entities;
using Domain.Entities.Commands;
using Domain.Entities.Commands.Cam;
using INotificationMessage = Domain.Entities.INotificationMessage;

namespace Services.Implementation;

public interface IServiceFactory
{
    ICarStatus CreateCarStatus<TCarKey>(ICar<TCarKey>? car) where TCarKey : struct;
    IMessageOptions CreateMessageOption(MessageType messageType, NotifyOptions options);
    ICarNumber CreateCarNumber(string? carNumber);
    INotificationMessage CreateMessage(ICarDetectedOnParking carDetectedOnParking);
    INotificationMessage CreateMessage(ICarIncidentOnParking carIncidentOnParking);
    INotificationMessage CreateMessage(IParkingClear carDetectedOnParking);
}