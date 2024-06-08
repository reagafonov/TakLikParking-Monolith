using Domain.Entities;
using Domain.Entities.Commands;
using Domain.Entities.Commands.Cam;
using MassTransit;
using INotificationMessage = Domain.Entities.INotificationMessage;

namespace Infrastructure.MassTransit;

public abstract class NotificationMessageBase<TDataType, TMessageType>(IPublishEndpoint publishEndpoint) : Domain.Entities.Commands.Cam.INotificationMessage
where TDataType:class
{
    protected abstract NotifyOptions NotifyOptions { get; }

    public async Task TrySendAsync(IMessageOptions carMessageOption,
        INotificationMessage message,
        ICollection<IContact> registrationDataContacts, CancellationToken token)
    {
        if (!carMessageOption.NotifyOptions.HasFlag(NotifyOptions))
            return;
        if(registrationDataContacts.Any(x=>x.GetType().IsAssignableTo(typeof(TDataType))))
        {
            TDataType? phoneNumber;
            phoneNumber = registrationDataContacts.FirstOrDefault(x=>x as TDataType is not null) as TDataType;
            var sms = GetMessage(message, phoneNumber);
            await publishEndpoint.Publish(sms, token);
        }
    }

    protected abstract TMessageType  GetMessage(INotificationMessage message, TDataType? data);
   
}