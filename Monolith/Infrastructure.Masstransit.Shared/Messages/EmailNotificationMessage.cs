namespace Infrastructure.Masstransit.Shared.Messages;

public class EmailNotificationMessage
{
    public string To { get; set; }
    
    public string Subject { get; set; }
    
    public string Text { get; set; }
}