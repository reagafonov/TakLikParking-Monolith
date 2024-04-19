using AutoMapper;
using Domain.Entities;
using Infrastructure.EntityFramework.Models;
using Services.Abstractions.New;

namespace Repositories.Implementations.New;

public class UserDataRepository(IMapper mapper,IRepository<UserDataEntity,Guid> repository, IUnitOfWork unitOfWork) : IUserRepository<Guid>
{
    public async Task<IUserData<Guid>> GetAsync(Guid userId, CancellationToken token)
    {
        var userData = await repository.GetAsync(userId, token);
        return mapper.Map<IUserData<Guid>>(userData);
    }

    public async Task AddAsync(IUserData<Guid> entity, CancellationToken token)
    {
        var data = mapper.Map<UserDataEntity>(entity);
        await repository.AddAsync(data,token);
        await unitOfWork.SaveChangesAsync(token);
    }
}