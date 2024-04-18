namespace Domain.Entities.New;

public class UserRegistrationData<TKey>:IEntity<TKey>
{
    public TKey Id { get; set; }
}