using Domain.Entities;
using Services.Abstractions;
using Services.Abstractions.New;

namespace Services.Implementation;

public class UserService<TUserKey,TCarKey>:IUserService<TUserKey,TCarKey> where TUserKey:struct where TCarKey:struct
{
    private readonly IUserRepository<TUserKey> _registrationRepository;
    private readonly ICarRepository<TCarKey> _carStatusRepository;
    private readonly IMessageFactory _messageFactory;


    public UserService(IUserRepository<TUserKey> registrationRepository,ICarRepository<TCarKey> carStatusRepository, IMessageFactory messageFactory)
    {
        _registrationRepository = registrationRepository;
        _carStatusRepository = carStatusRepository;
        _messageFactory = messageFactory;
    }

    public async Task CreateAsync(IUserData<TUserKey> userData, CancellationToken token)
    {
        await _registrationRepository.AddAsync(userData, token);
    }

   

    public async Task SetNotificationOptionsAsync(TUserKey userId, TCarKey carKey, MessageType type,
        NotifyOptions options, CancellationToken token)
    {
        var car = await _carStatusRepository.GetAsync(carKey, token);
        var messageTypes = Enum.GetValues<MessageType>().Where(x => type.HasFlag(x)).ToList();
        if (options != NotifyOptions.None)
        {
            foreach (var messageType in messageTypes)
            {
                if (!car.MessageOptions.ContainsKey(messageType))
                    car.MessageOptions[messageType] = _messageFactory.CreateMessageOption(messageType, options);
                else
                    car.MessageOptions[messageType].NotifyOptions |= options;
            }
        }
        
        await _carStatusRepository.UpdateAsync(token);
    }
}