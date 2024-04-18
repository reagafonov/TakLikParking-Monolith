namespace Repository.Abstractions.New;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken token);
}