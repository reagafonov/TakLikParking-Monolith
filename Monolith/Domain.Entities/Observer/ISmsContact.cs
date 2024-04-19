namespace Domain.Entities;

public interface ISmsContact:IContact
{
    string PhoneNumber { get; set; }
}