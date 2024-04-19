// See https://aka.ms/new-console-template for more information

using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Services.Shared.Messages.Camera;

string? GetNumber()
{
    Console.WriteLine("Введите номер:");
    var number = Console.ReadLine();
    return number;
}

var serviceCollection = new ServiceCollection();
serviceCollection.AddMassTransit(bus=>
{
    bus.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "test", h =>
        {
            h.Username("test");
            h.Password("1234");
        });
        cfg.Publish<CarOnParkingMessage>(x =>
        {
            x.ExchangeType = "direct";
        });
    });
});
var provider = serviceCollection.BuildServiceProvider();
var endPoint = provider.GetRequiredService<IPublishEndpoint>();
while (true)
{
    
    Console.WriteLine("""
                          1.Машина на парковке
                          2.Тревога
                          3.Машина покинула парковку
                          4.Выход
                      """);
    var result = Console.ReadKey(true);
    var tokenSource = new CancellationTokenSource();
    string number;
    switch (result.KeyChar)
    {
        case <'1' or > '4':
            continue;
        case '1':
            number = GetNumber();
            await endPoint.Publish(new CarOnParkingMessage()
            {
                CarNumber = number
            }, tokenSource.Token);
            break;
        case '2':
            number = GetNumber();
            await endPoint.Publish(new CarIncidentMessage()
            {
                CarNumber = number
            }, tokenSource.Token);
            break;
        case '3':
            number = GetNumber();
            await endPoint.Publish(new CarLeaveParkingMessage()
            {
                CarNumber = number
            }, tokenSource.Token);
            break;
        case '4':
            return;
    }
}

