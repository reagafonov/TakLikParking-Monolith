namespace Services.Shared.Messages.Observer;

public class SmsNotificationMessage
{
    public string PhoneNumber { get; set; }
    
    public string Contents { get; set; }
}