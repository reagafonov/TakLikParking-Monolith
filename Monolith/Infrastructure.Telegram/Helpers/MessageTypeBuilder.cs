
using Domain.Entities;

namespace Infrastructure.Telegram;

public class MessageTypeBuilder
{
    private MessageType _messageType = MessageType.None;
    private NotifyOptions _notifyOptions = NotifyOptions.None;

    private void SetNotifyOption(NotifyOptions flag, bool value) =>
        _notifyOptions = EnumHelper.SeNotifyOptions(_notifyOptions, flag, value);
    
    public void SetTelegram(bool isSet)
    {
        SetNotifyOption(NotifyOptions.Telegram,isSet);
    }

    public void SetEmail(bool isSet) => SetNotifyOption(NotifyOptions.Email, isSet);

    public (MessageType, NotifyOptions) Build() => (_messageType, _notifyOptions);
}