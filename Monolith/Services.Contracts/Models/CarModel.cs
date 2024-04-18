using Domain.Entities;

namespace Services.Contracts.Models;

public class CarModel:ICar<Guid>
{
    public Guid Id { get; set; }
    public ICarNumber Number { get; set; }
    public IDictionary<MessageType, IMessageOptions> MessageOptions { get; set; }
    public ICollection<IUserData<Guid>> RegistrationData { get; set; }
}