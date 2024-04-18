using Domain.Entities;
using Domain.Entities.New;
using Microsoft.Extensions.DependencyInjection;
using Repository.Abstractions.New;

namespace Repositories.Implementations.New;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterPg(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IRepository<,>), typeof(CommonRepository<,>));
        serviceCollection.AddScoped<IRepository<ICar<Guid>, Guid>, CarRepository>();
        serviceCollection.AddScoped<ICarRepository<Guid>, CarRepository>();
        serviceCollection.AddScoped<IRepository<IUserData<Guid>, Guid>, UserDataRepository>();
        serviceCollection.AddScoped<IUserRepository<Guid>, UserDataRepository>();
        return serviceCollection;
    }
}