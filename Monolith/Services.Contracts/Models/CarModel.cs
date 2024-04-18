using Domain.Entities;
using Domain.Entities.New;

namespace WebApi.Contracts.Dtos;

public class CarModel:ICar<Guid>
{
    public Guid Id { get; set; }
    public ICarNumber Number { get; set; }
    public IDictionary<MessageType, IMessageOptions> MessageOptions { get; set; }
    public ICollection<IUserData<Guid>> RegistrationData { get; set; }
}