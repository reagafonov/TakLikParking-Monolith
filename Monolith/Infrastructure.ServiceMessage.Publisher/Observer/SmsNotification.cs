using Domain.Entities;
using MassTransit;
using Services.Shared.Messages.Observer;

namespace Infrastructure.MassTransit;

public abstract class SmsNotification(IPublishEndpoint publishEndpoint)
    : NotificationMessageBase<IPhoneNumber, SmsNotificationMessage>(publishEndpoint)
{
    protected override NotifyOptions NotifyOptions => NotifyOptions.Sms;


    protected override SmsNotificationMessage GetMessage(INotificationMessage message, IPhoneNumber? data)
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