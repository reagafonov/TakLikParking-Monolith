namespace Services.Abstractions.New;

/// <summary>
/// Отсылает уведомление клиенту
/// </summary>
public interface INotificationService
{
    Task SendAsync(INotificationService message, CancellationToken token);
}