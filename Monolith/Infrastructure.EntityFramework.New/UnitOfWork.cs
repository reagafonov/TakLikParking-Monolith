using Repository.Abstractions.New;

namespace Infrastructure.EntityFramework.New;

public class UnitOfWork:IUnitOfWork
{
    private readonly DatabaseContext _databaseContext;

    public UnitOfWork(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task SaveChangesAsync(CancellationToken token)
    {
        await _databaseContext.SaveChangesAsync(token);
    }
}