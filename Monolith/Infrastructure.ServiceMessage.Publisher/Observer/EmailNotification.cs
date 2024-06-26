using Domain.Entities;
using MassTransit;
using Services.Shared.Messages.Observer;

namespace Infrastructure.MassTransit;

public class EmailNotification(IPublishEndpoint publishEndpoint)
    : NotificationMessageBase<IEmailContact, EmailNotificationMessage>(publishEndpoint)
{
    protected override NotifyOptions NotifyOptions => NotifyOptions.Email;
    protected override EmailNotificationMessage GetMessage(INotificationMessage message, IEmailContact? data)
    {
        return new EmailNotificationMessage()
        {
            Subject = "Сообщение TakLikParking",
            Text = message.MessageText,
            To = data.Email
        };
    }
}