using Domain.Entities.New;

namespace Domain.Entities.Commands;

public interface INotificationMessage
{
    Task TrySendAsync(IMessageOptions carMessageOption, INotificationMessageData message,
        ICollection<IContact> registrationDataContacts, CancellationToken token);
}