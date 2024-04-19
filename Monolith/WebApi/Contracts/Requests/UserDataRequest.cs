
namespace WebApi.Contracts.Requests;

public class UserDataRequest
{
    public ICollection<CarRequest> Cars { get; set; }
    
    public TelegramContactRequest TelegramContact { get; set; }
}