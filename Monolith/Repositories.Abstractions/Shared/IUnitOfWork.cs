namespace Services.Abstractions.New;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken token);
}