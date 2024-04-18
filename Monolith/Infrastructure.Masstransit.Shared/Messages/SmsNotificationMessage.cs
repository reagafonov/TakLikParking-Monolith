namespace Infrastructure.Masstransit.Shared.Messages;

public class SmsNotificationMessage
{
    public string PhoneNumber { get; set; }
    
    public string Contents { get; set; }
}