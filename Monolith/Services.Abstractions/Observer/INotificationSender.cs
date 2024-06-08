namespace Services.Abstractions.New;

/// <summary>
/// Отсылает уведомление клиенту
/// </summary>
public interface INotificationSender
{
    Task SendAsync(INotificationSender message, CancellationToken token);
}