using Domain.Entities;
using Domain.Entities.New;

namespace Infrastructure.Telegram;

public class TelegramCar:ICar<Guid>
{
    public Guid Id { get; set; }
    public ICarNumber Number { get; set; }
    public IDictionary<MessageType, IMessageOptions> MessageOptions { get; set; }
    public ICollection<IUserData<Guid>> RegistrationData { get; set; }
}