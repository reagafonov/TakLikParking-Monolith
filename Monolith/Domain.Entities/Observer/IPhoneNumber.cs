namespace Domain.Entities;

public interface IPhoneNumber:IContact
{
    string PhoneNumber { get; set; }
}