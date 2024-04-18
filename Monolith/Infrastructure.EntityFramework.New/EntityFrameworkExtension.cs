using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Abstractions.New;

namespace Infrastructure.EntityFramework.New;

public static class EntityFrameworkExtension
{
    public static IServiceCollection ConfigureContext(this IServiceCollection collection, string connectionString)
    {
        collection.AddDbContext<DatabaseContext>(o => o.UseLazyLoadingProxies()
            .UseNpgsql(connectionString), ServiceLifetime.Scoped);
        collection.AddScoped<IUnitOfWork, UnitOfWork>();
        return collection;
    }
}