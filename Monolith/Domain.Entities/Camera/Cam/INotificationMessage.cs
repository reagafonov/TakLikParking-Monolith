namespace Domain.Entities.Commands.Cam;

public interface INotificationMessage
{
    Task TrySendAsync(IMessageOptions carMessageOption, Entities.INotificationMessage message,
        ICollection<IContact> registrationDataContacts, CancellationToken token);
}