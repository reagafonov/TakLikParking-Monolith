using Domain.Entities;
using Domain.Entities.Commands;
using Domain.Entities.Commands.Cam;
using Services.Abstractions;
using Services.Abstractions.New;

namespace Services.Implementation;

public class AggregatorService<TCarKey>:IAggregatorService where TCarKey:struct
{
    private readonly ICarRepository<TCarKey> _repository;
    private readonly IEnumerable<INotificationMessage> _notificationMessages;
    private readonly IServiceFactory _serviceFactory;

    public AggregatorService(IEnumerable<INotificationMessage> notificationMessages, ICarRepository<TCarKey> repository, IServiceFactory serviceFactory)
    {
        _notificationMessages = notificationMessages;
        _repository = repository;
        _serviceFactory = serviceFactory;
    }

    public async Task OnCarDetectedOnParkingAsync(ICarDetectedOnParking carDetectedOnParking, CancellationToken token)
    {
        await SendMessageAsync(MessageType.Parking, _serviceFactory.CreateMessage(carDetectedOnParking), carDetectedOnParking.CarNumber, token);
    }

    private async Task SendMessageAsync(MessageType messageType, INotificationMessageData message, string carNumber,
        CancellationToken token)
    {
        var number = _serviceFactory.CreateCarNumber(carNumber);
        var car = await _repository.GetAsync(number, token);
        var registrationDatas = car.RegistrationData;
        if(!car.MessageOptions.Any(options=>options.Key.HasFlag(messageType)))
            return;
        foreach (var notificationMessage in _notificationMessages)
        {
            foreach (var registrationData in registrationDatas)
            {
                await notificationMessage.TrySendAsync(car.MessageOptions[messageType], message,
                    registrationData.Contacts, token);
            }
        }
    }

    public async Task OnCarIncidentOnParkingAsync(ICarIncidentOnParking carIncidentOnParking, CancellationToken token)
    {
        await SendMessageAsync(MessageType.Incident, _serviceFactory.CreateMessage(carIncidentOnParking),
            carIncidentOnParking.CarNumber, token);
    }

    public async Task OnParkingClearAsync(IParkingClear parkingClear, CancellationToken token)
    {
        await SendMessageAsync(MessageType.Parking, _serviceFactory.CreateMessage(parkingClear), parkingClear.CarNumber,
            token);
    }
}