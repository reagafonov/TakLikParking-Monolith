using Domain.Entities.New;

namespace Repositories.Implementations.New.Models;

public class SmsContactModel:ISmsContact
{
    public string PhoneNumber { get; set; }
}