using Microsoft.Extensions.Options;
using Services.Abstractions;
using Services.Abstractions.New;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Infrastructure.Telegram;

public class TelegramRepository : ITelegramRepository
{
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly ReceiverOptions _receiverOptions;
    private readonly IUserService<Guid,Guid> _userService;

    public TelegramRepository(IOptions<TelegramOptions> options, IUserService<Guid, Guid> userService)
    {
        _userService = userService;
        _telegramBotClient = new TelegramBotClient(options.Value?.ApiKey ?? string.Empty);
        _receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = new[]
            {
                UpdateType.Message,
                UpdateType.ChatJoinRequest,
            },
        };
    }

    public async Task SendMessageAsync(string identifier, string message, CancellationToken token)
    {
        await _telegramBotClient.SendTextMessageAsync(new ChatId(identifier), message, cancellationToken: token);
    }

    public void StartService()
    {
        _telegramBotClient.StartReceiving(UpdateHandler,ErrorHandler,_receiverOptions,default);
    }

    private Task ErrorHandler(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
    {
        throw new NotImplementedException();
    }

    private Task UpdateHandler(ITelegramBotClient arg1, Update arg2, CancellationToken arg3)
    {
        throw new NotImplementedException();
    }
}