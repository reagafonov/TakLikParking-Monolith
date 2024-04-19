namespace Domain.Entities.Commands.Cam;

public interface INotificationMessage
{
    Task TrySendAsync(IMessageOptions carMessageOption, INotificationMessageData message,
        ICollection<IContact> registrationDataContacts, CancellationToken token);
}