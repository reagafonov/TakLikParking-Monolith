using Domain.Entities;
using Domain.Entities.New;

namespace Infrastructure.Telegram;

public class TelegramUser:IUserData<Guid>
{
    public ICollection<ICar<Guid>> Cars { get; set; }
    public ICollection<IContact> Contacts { get; set; }
}