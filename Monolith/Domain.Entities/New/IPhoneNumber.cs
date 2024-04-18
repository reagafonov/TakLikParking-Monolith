using Domain.Entities.New;

namespace Domain.Entities;

public interface IPhoneNumber:IContact
{
    string PhoneNumber { get; set; }
}