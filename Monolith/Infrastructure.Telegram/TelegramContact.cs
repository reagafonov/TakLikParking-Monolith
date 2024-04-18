using Domain.Entities.New;

namespace Infrastructure.Telegram;

public class TelegramContact:ITelegramContact,ISmsContact
{
    public string Name { get; set; }
    
    public string ChatID { get; set; }
    
    public string PhoneNumber { get; set; }
}