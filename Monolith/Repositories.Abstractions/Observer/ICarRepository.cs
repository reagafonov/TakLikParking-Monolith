using Domain.Entities;

namespace Services.Abstractions.New;

public interface ICarRepository<TCarKey>:IRepository<ICar<TCarKey>,TCarKey> where TCarKey:struct
{
    Task<ICar<Guid>?> GetAsync(ICarNumber carNumber, CancellationToken token);
    Task UpdateAsync(CancellationToken token);
}