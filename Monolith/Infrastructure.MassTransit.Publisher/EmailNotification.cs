using Domain.Entities;
using Domain.Entities.New;
using Infrastructure.Masstransit.Shared.Messages;
using MassTransit;

namespace Infrastructure.MassTransit;

public class EmailNotification(IPublishEndpoint publishEndpoint)
    : NotificationMessageBase<IEmailContact, EmailNotificationMessage>(publishEndpoint)
{
    protected override NotifyOptions NotifyOptions => NotifyOptions.Email;
    protected override EmailNotificationMessage GetMessage(INotificationMessageData message, IEmailContact? data)
    {
        return new EmailNotificationMessage()
        {
            Subject = "Сообщение TakLikParking",
            Text = message.MessageText,
            To = data.Email
        };
    }
}