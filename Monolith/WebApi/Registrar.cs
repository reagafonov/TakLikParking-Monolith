using Infrastructure.EntityFramework;
using Infrastructure.MassTransit.Camera;
using Infrastructure.Masstransit.Consumer.Camera;
using Infrastructure.Masstransit.Consumer.Observer;
using Infrastructure.Telegram;
using MassTransit;
using WebApi.Settings;
using Repositories.Implementations.New;
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
                x.AddConsumer<TelegramConsumer>();
                x.AddConsumer<CarOnParkingConsumer>();
                x.AddConsumer<CarIncidentConsumer>();
                x.AddConsumer<CarLeaveParkingConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri("rabbitmq://localhost:5672/test"), "test", h =>
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
            serviceCollection.AddScoped<IAggregatorService, AggregatorService<Guid>>();
            return serviceCollection;
        }
        
        private static IServiceCollection InstallRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITelegramRepository, TelegramRepository>();
            serviceCollection.AddScoped<IParkingRepository, MassTransitParkingRepository>();
            return serviceCollection;
        }
    }
}