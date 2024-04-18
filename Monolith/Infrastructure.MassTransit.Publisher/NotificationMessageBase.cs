using Domain.Entities;
using Domain.Entities.Commands;
using Domain.Entities.New;
using MassTransit;

namespace Infrastructure.MassTransit;

public abstract class NotificationMessageBase<TDataType, TMessageType>(IPublishEndpoint publishEndpoint) : INotificationMessage
where TDataType:class
{
    protected abstract NotifyOptions NotifyOptions { get; }

    public async Task TrySendAsync(IMessageOptions carMessageOption,
        INotificationMessageData message,
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

    protected abstract TMessageType  GetMessage(INotificationMessageData message, TDataType? data);
   
}