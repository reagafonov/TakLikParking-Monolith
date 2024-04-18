using Infrastructure.Masstransit.Shared.Messages;
using Infrastructure.Telegram;
using MassTransit;

namespace Infrastructure.Masstransit.Consumer;

public class TelegramConsumer:IConsumer<TelegramNotificationMessage>
{
    private readonly ITelegramRepository _telegramRepository;

    public TelegramConsumer(ITelegramRepository telegramRepository)
    {
        _telegramRepository = telegramRepository;
    }

    public async Task Consume(ConsumeContext<TelegramNotificationMessage> context)
    {
        var telegramNotificationMessage = context.Message;
        await _telegramRepository.SendMessageAsync(telegramNotificationMessage.Name, telegramNotificationMessage.Message, default);
    }
}