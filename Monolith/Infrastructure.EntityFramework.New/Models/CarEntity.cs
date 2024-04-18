using Infrastructure.EntityFramework.New.Models;

namespace Infrastructure.EntityFramework.Models;

public class CarEntity
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public virtual ICollection<MessageOptionsEntity> MessageOptions { get; set; }
    public virtual ICollection<UserDataEntity> RegistrationData { get; set; }
}