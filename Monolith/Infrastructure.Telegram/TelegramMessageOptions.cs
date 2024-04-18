using Domain.Entities;
using Domain.Entities.New;

namespace Infrastructure.Telegram;

public class TelegramMessageOptions:IMessageOptions
{
    public NotifyOptions NotifyOptions { get; set; }
}