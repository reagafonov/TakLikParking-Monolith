using Domain.Entities;
using MassTransit;
using Services.Abstractions.New;
using Services.Shared.Messages.Camera;

namespace Infrastructure.MassTransit.Camera;

public class MassTransitParkingRepository(IPublishEndpoint endPoint):IParkingRepository
{
    
    public async Task CarOnParkingAsync(ICarNumber carNumber, CancellationToken token)
    {
        await endPoint.Publish(new CarOnParkingMessage()
        {
            CarNumber = carNumber.Number
        }, token);
    }

    public async Task CarIncidentAsync(ICarNumber carNumber, CancellationToken token)
    {
        await endPoint.Publish(new CarIncidentMessage()
        {
            CarNumber = carNumber.Number
        }, token);
    }

    public async Task CarLeaveParkingAsync(ICarNumber carNumber, CancellationToken token)
    {
        await endPoint.Publish(new CarLeaveParkingMessage()
        {
            CarNumber = carNumber.Number
        }, token);
    }
}