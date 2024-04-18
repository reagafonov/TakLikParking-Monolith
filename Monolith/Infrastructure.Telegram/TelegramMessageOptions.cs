using Domain.Entities;

namespace Infrastructure.Telegram;

public class TelegramMessageOptions:IMessageOptions
{
    public NotifyOptions NotifyOptions { get; set; }
}