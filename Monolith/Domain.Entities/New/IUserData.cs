namespace Domain.Entities.New;

public interface IUserData<TCarKey> where TCarKey:struct
{
    ICollection<ICar<TCarKey>> Cars { get; set; }

    ICollection<IContact> Contacts { get; set; }
}