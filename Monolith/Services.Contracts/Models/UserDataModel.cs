using Domain.Entities;

namespace Services.Contracts.Models;

public class UserDataModel:IUserData<Guid>
{
    public ICollection<ICar<Guid>> Cars { get; set; }
    public ICollection<IContact> Contacts { get; set; }
}