using Domain.Entities;
using Domain.Entities.New;
using Infrastructure.Masstransit.Shared.Messages;
using MassTransit;

namespace Infrastructure.MassTransit;

public abstract class SmsNotification(IPublishEndpoint publishEndpoint)
    : NotificationMessageBase<IPhoneNumber, SmsNotificationMessage>(publishEndpoint)
{
    protected override NotifyOptions NotifyOptions => NotifyOptions.Sms;


    protected override SmsNotificationMessage GetMessage(INotificationMessageData message, IPhoneNumber? data)
    {
        var number = data.PhoneNumber;
        var sms = new SmsNotificationMessage()
        {
            PhoneNumber = number,
            Contents = message.MessageText
        };
        return sms;
    }
}