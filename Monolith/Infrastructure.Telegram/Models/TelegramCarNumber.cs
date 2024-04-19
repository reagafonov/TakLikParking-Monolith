using Domain.Entities;

namespace Infrastructure.Telegram;

public class TelegramCarNumber:ICarNumber
{
    public string? Number { get; set; }
}