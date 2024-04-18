using Domain.Entities;

namespace Repositories.Implementations.New.Models;

public class SmsContactModel:ISmsContact
{
    public string PhoneNumber { get; set; }
}