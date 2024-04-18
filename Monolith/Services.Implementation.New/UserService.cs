using Domain.Entities;
using Domain.Entities.New;
using Repository.Abstractions.New;
using Services.Abstractions;

namespace Services.Implementation.New;

public class UserService<TUserKey,TCarKey>:IUserService<TUserKey,TCarKey> where TUserKey:struct where TCarKey:struct
{
    private readonly IUserRepository<TUserKey> _registrationRepository;
    private readonly ICarRepository<TCarKey> _carStatusRepository;
    private readonly IServiceFactory _serviceFactory;
    private readonly IUnitOfWork _unitOfWork;
    

    public UserService(IUserRepository<TUserKey> registrationRepository,ICarRepository<TCarKey> carStatusRepository, IServiceFactory serviceFactory, IUnitOfWork unitOfWork)
    {
        _registrationRepository = registrationRepository;
        _carStatusRepository = carStatusRepository;
        _serviceFactory = serviceFactory;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(IUserData<TUserKey> userData, CancellationToken token)
    {
        await _registrationRepository.AddAsync(userData, token);
    }

    public async Task<ICarStatus> GetStatusAsync(TUserKey userId, TCarKey carKey, CancellationToken token)
    {
        var carTask = _carStatusRepository.GetAsync(carKey, token);
        var car = await carTask;
        var carStatus = _serviceFactory.CreateCarStatus(car);
        return carStatus;
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
                    car.MessageOptions[messageType] = _serviceFactory.CreateMessageOption(messageType, options);
                else
                    car.MessageOptions[messageType].NotifyOptions |= options;
            }
        }

        await _unitOfWork.SaveChangesAsync(token);
    }
}