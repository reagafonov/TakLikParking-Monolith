using Domain.Entities;

namespace Repositories.Implementations.New.Models;

public class CarModel:ICar<Guid>
{
    public Guid Id { get; set; }
    public ICarNumber Number { get; set; }
    public MessageType MessageType { get; set; }
    public IDictionary<MessageType, IMessageOptions> MessageOptions { get; set; }
    public ICollection<IUserData<Guid>> RegistrationData { get; set; }
}