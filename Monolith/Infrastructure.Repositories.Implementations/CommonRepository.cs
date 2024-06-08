using Infrastructure.EntityFramework;
using Services.Abstractions.New;

namespace Repositories.Implementations.New;

public class CommonRepository<TEntity, TKey>(DatabaseContext context) : IRepository<TEntity, TKey>
    where TEntity : class
    where TKey : struct
{
    public async Task<TEntity?> GetAsync(TKey userId, CancellationToken token)
    {
        return await context.Set<TEntity>().FindAsync(userId, token);
    }

    public async Task AddAsync(TEntity entity, CancellationToken token)
    {
        await context.Set<TEntity>().AddAsync(entity, token);
        await context.SaveChangesAsync(token);
    }

    public async Task UpdateAsync(CancellationToken token)
    {
        await context.SaveChangesAsync(token);
    }
}