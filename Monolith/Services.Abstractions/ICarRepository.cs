using Domain.Entities;
using Domain.Entities.New;

namespace Repository.Abstractions.New;

public interface ICarRepository<TCarKey>:IRepository<ICar<TCarKey>,TCarKey> where TCarKey:struct
{
    Task<ICar<Guid>?> GetAsync(ICarNumber userId, CancellationToken token);
}