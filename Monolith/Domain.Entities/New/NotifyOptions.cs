namespace Domain.Entities;

[Flags]
public enum NotifyOptions
{
    None= 0,
    Sms = 1,
    Email = 1<<1,
    // PhoneCall = 1<<2,
    TelegramSms = 1<<3,
    // TelegramCall = 1<<4
}