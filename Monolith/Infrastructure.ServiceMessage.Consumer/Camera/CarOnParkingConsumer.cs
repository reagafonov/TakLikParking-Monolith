using MassTransit;
using Services.Abstractions.New;
using Services.Shared.Messages.Camera;

namespace Infrastructure.Masstransit.Consumer.Camera;

public class CarOnParkingConsumer(IAggregatorService aggregatorService) : IConsumer<CarOnParkingMessage>
{

    public async Task Consume(ConsumeContext<CarOnParkingMessage> context)
    {
        await aggregatorService.OnCarDetectedOnParkingAsync(context.Message, context.CancellationToken);
    }
}