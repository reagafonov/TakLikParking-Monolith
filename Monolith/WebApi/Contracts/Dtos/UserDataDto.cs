using Domain.Entities;

namespace WebApi.Contracts.Dtos;

public class UserDataDto:IUserData<Guid>
{
    public ICollection<ICar<Guid>> Cars { get; set; }
    public ICollection<IContact> Contacts { get; set; }
}