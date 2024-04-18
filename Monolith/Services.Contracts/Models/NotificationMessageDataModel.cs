using Domain.Entities.New;

namespace Services.Contracts.Models;

public class NotificationMessageDataModel:INotificationMessageData
{
    public string MessageText { get; set; }
}