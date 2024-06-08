using Domain.Entities;

namespace Services.Contracts.Models;

public class NotificationMessageModel:INotificationMessage
{
    public string MessageText { get; set; }
}