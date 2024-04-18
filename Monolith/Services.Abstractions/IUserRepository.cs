using Domain.Entities.New;

namespace Repository.Abstractions.New;

public interface IUserRepository<TUserKey> : IRepository<IUserData<TUserKey>,TUserKey> where TUserKey:struct
{
    
}