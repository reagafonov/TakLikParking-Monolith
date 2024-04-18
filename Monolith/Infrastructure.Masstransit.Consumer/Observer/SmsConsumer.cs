using Infrastructure.Masstransit.Shared.Messages;
using MassTransit;

namespace Infrastructure.Masstransit.Consumer.Observer;

public class SmsConsumer:IConsumer<SmsNotificationMessage>
{
    public Task Consume(ConsumeContext<SmsNotificationMessage> context)
    {
        throw new NotImplementedException();
    }
}