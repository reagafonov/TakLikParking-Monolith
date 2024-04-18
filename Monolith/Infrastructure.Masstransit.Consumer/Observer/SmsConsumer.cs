using MassTransit;
using Services.Shared.Messages.Observer;

namespace Infrastructure.Masstransit.Consumer.Observer;

public class SmsConsumer:IConsumer<SmsNotificationMessage>
{
    public Task Consume(ConsumeContext<SmsNotificationMessage> context)
    {
        throw new NotImplementedException();
    }
}