
using MassTransit;
using Services.Abstractions.New;
using Services.Shared.Messages.Camera;

namespace Infrastructure.Masstransit.Consumer.Camera;

public class CarLeaveParkingConsumer(IAggregatorService aggregatorService):IConsumer<CarLeaveParkingMessage>
{
    public async Task Consume(ConsumeContext<CarLeaveParkingMessage> context)
    {
        await aggregatorService.OnParkingClearAsync(context.Message, context.CancellationToken);
    }
}