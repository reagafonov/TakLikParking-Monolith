
namespace WebApi.Contracts.Requests;

public class UserDataRequest
{
    public List<CarRequest> Cars { get; set; }
    
    public TelegramContactRequest TelegramContact { get; set; }
}