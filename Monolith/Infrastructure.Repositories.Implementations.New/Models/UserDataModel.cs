using Domain.Entities;
using Domain.Entities.New;

namespace Repositories.Implementations.New.Models;

public class UserDataDto:IUserData<Guid>
{
    public ICollection<ICar<Guid>> Cars { get; set; }
    public ICollection<IContact> Contacts { get; set; }
}