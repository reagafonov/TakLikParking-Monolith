namespace Infrastructure.Telegram;

public interface ITelegramRepository
{
    Task SendMessageAsync(string identifier, string message, CancellationToken token);
    void StartService();
}