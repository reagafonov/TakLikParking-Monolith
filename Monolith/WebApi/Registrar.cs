using Infrastructure.EntityFramework;
using Infrastructure.Masstransit.Consumer;
using Infrastructure.Masstransit.Consumer.Observer;
using MassTransit;
using WebApi.Settings;
using Repositories.Implementations.New;
using Services.Abstractions;
using Services.Abstractions.New;
using Services.Implementation;

namespace WebApi
{
    /// <summary>
    /// Регистратор сервиса
    /// </summary>
    public static class Registrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettings = configuration.Get<ApplicationSettings>()!;
            services.AddSingleton(applicationSettings);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMassTransit(x =>
            {
                x.AddConsumer<SmsConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "test", h =>
                    {
                        h.Username("test");
                        h.Password("1234");
                    });
                });
            });
            return services.AddSingleton((IConfigurationRoot)configuration)
                .InstallServices()
                .ConfigureContext(applicationSettings.ConnectionString)
                .InstallRepositories()
                .RegisterPg();
        }
        
        private static IServiceCollection InstallServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IUserService<,>), typeof(UserService<,>));
            serviceCollection.AddSingleton<IServiceFactory, ServiceFactory>();
            return serviceCollection;
        }
        
        private static IServiceCollection InstallRepositories(this IServiceCollection serviceCollection)
        {
          
            return serviceCollection;
        }
    }
}