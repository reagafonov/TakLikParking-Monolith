// See https://aka.ms/new-console-template for more information

using CameraConsole;
using Infrastructure.MassTransit.Camera;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstractions.New;
using Services.Shared.Messages.Camera;

string? GetNumber()
{
    Console.WriteLine("Введите номер:");
    var number = Console.ReadLine();
    return number;
}

var serviceCollection = new ServiceCollection();
serviceCollection.AddScoped<IParkingRepository, MassTransitParkingRepository>();
serviceCollection.AddMassTransit(bus=>
{
    bus.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri("rabbitmq://localhost:5672/test"), "test", h =>
        {
            h.Username("test");
            h.Password("1234");
        });
        cfg.Publish<CarOnParkingMessage>();
        cfg.Publish<CarIncidentMessage>();
        cfg.Publish<CarLeaveParkingMessage>();
        cfg.ConfigureEndpoints(context, new DefaultEndpointNameFormatter(true));
    });
});


var provider = serviceCollection.BuildServiceProvider();
var endPoint = provider.GetRequiredService<IParkingRepository>();
while (true)
{
    
    Console.WriteLine("""
                          1.Машина на парковке
                          2.Тревога
                          3.Машина покинула парковку
                          4.Выход
                      """);
    var result = Console.ReadKey();
    Console.WriteLine();
    var tokenSource = new CancellationTokenSource();
    string? number;
    switch (result.KeyChar)
    {
        case <'1' or > '4':
            continue;
        case '1':
            number = GetNumber();
            await endPoint.CarOnParkingAsync(new CarNumber()
            {
                Number = number
            }, tokenSource.Token);
            break;
        case '2':
            number = GetNumber();
            await endPoint.CarIncidentAsync(new CarNumber()
            {
                Number = number
            }, tokenSource.Token);
            break;
        case '3':
            number = GetNumber();
            await endPoint.CarLeaveParkingAsync(new CarNumber()
            {
                Number = number
            }, tokenSource.Token);
            break;
        case '4':
            return;
    }
}

