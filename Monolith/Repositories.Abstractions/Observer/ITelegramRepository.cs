namespace Services.Abstractions.New;

public interface ITelegramRepository
{
    Task SendMessageAsync(string identifier, string message, CancellationToken token);
    void StartService();
}