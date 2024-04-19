
namespace Services.Abstractions.New;

public interface IRepository<TEntity,TKey> where TKey:struct
{
    Task<TEntity?> GetAsync(TKey userId, CancellationToken token);
    Task AddAsync(TEntity entity, CancellationToken token);
    
}