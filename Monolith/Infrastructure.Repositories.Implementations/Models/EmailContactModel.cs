using Domain.Entities.New;

namespace Repositories.Implementations.New.Models;

public class EmailContactModel:IEmailContact
{
    public string Email { get; set; }
}