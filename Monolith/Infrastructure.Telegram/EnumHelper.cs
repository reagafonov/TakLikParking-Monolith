using Domain.Entities;

namespace Infrastructure.Telegram;

public static class EnumHelper
{
    public static MessageType SeMessageType(MessageType type, MessageType flag, bool value)
    {
        if (value)
            type |= flag;
        else
            type &= (~flag);
        return type;
    }
    
    public static NotifyOptions SeNotifyOptions(NotifyOptions type, NotifyOptions flag, bool value)
    {
        if (value)
            type |= flag;
        else
            type &= (~flag);
        return type;
    }
    
    
}