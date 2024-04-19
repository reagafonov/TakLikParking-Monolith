using Domain.Entities;

namespace Services.Abstractions.New;

public interface IUserRepository<TUserKey> : IRepository<IUserData<TUserKey>,TUserKey> where TUserKey:struct
{
    
}