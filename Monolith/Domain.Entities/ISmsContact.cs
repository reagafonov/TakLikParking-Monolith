namespace Domain.Entities.New;

public interface ISmsContact:IContact
{
    string PhoneNumber { get; set; }
}