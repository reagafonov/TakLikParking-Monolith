using Domain.Entities.New;

namespace Domain.Entities;

public interface ICar<TKey> : IEntity<TKey> where TKey:struct
{
     TKey Id { get; set; }
     
     ICarNumber Number { get; set; }
     IDictionary<MessageType,IMessageOptions> MessageOptions { get; set; }
     ICollection<IUserData<TKey>> RegistrationData { get; set; }
}