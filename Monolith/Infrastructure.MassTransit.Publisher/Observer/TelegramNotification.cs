using Domain.Entities;
using MassTransit;
using Services.Shared.Messages.Observer;

namespace Infrastructure.MassTransit;

public class TelegramNotification(IPublishEndpoint publishEndpoint)
    : NotificationMessageBase<ITelegramContact, TelegramNotificationMessage>(publishEndpoint)
{
    protected override NotifyOptions NotifyOptions => NotifyOptions.TelegramSms; 
    protected override TelegramNotificationMessage GetMessage(INotificationMessageData message, ITelegramContact? data)
    {
        return new TelegramNotificationMessage
        {
            Name = data.Name,
            Message = message.MessageText
        };
    }
}