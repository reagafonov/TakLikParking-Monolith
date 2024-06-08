using Domain.Entities;
using Domain.Entities.Commands;
using Domain.Entities.Commands.Cam;
using Services.Abstractions;
using Services.Abstractions.New;
using INotificationMessage = Domain.Entities.INotificationMessage;

namespace Services.Implementation;

public class AggregatorService<TCarKey>:IAggregatorService where TCarKey:struct
{
    private readonly ICarRepository<TCarKey> _repository;
    private readonly IMessageFactory _messageFactory;
    private readonly IEnumerable<Domain.Entities.Commands.Cam.INotificationMessage> _notificationMessages;
    private readonly ICarFactory _carFactory;

    public AggregatorService(IEnumerable<Domain.Entities.Commands.Cam.INotificationMessage> notificationMessages, ICarRepository<TCarKey> repository, ICarFactory carFactory, IMessageFactory messageFactory)
    {
        _notificationMessages = notificationMessages;
        _repository = repository;
        _carFactory = carFactory;
        _messageFactory = messageFactory;
    }

    public async Task OnCarDetectedOnParkingAsync(ICarDetectedOnParking carDetectedOnParking, CancellationToken token)
    {
        await SendMessageAsync(MessageType.Parking, _messageFactory.CreateMessage(carDetectedOnParking), carDetectedOnParking.CarNumber, token);
    }

    private async Task SendMessageAsync(MessageType messageType, INotificationMessage message, string? carNumber,
        CancellationToken token)
    {
        var number = _carFactory.CreateCarNumber(carNumber);
        var car = await _repository.GetAsync(number, token);
        if (car is null)
            return;
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
        await SendMessageAsync(MessageType.Incident, _messageFactory.CreateMessage(carIncidentOnParking),
            carIncidentOnParking.CarNumber, token);
    }

    public async Task OnParkingClearAsync(IParkingClear parkingClear, CancellationToken token)
    {
        await SendMessageAsync(MessageType.Parking, _messageFactory.CreateMessage(parkingClear), parkingClear.CarNumber,
            token);
    }
}