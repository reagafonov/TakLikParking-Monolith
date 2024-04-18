using Infrastructure.Masstransit.Shared.Messages;
using MassTransit;
using Services.Abstractions.New;

namespace Infrastructure.Masstransit.Consumer.Observer;

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