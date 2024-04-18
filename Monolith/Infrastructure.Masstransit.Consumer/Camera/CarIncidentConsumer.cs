using MassTransit;
using Services.Abstractions.New;
using Services.Shared.Messages.Camera;

namespace Infrastructure.Masstransit.Consumer.Camera;

public class CarIncidentConsumer(IAggregatorService aggregatorService):IConsumer<CarIncidentMessage>
{
    public async Task Consume(ConsumeContext<CarIncidentMessage> context)
    {
        await aggregatorService.OnCarIncidentOnParkingAsync(context.Message, context.CancellationToken);
    }
}