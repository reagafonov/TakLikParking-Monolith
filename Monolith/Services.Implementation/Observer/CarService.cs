using Domain.Entities;
using Services.Abstractions.New;

namespace Services.Implementation;

public class CarService<TUserKey,TCarKey>:ICarService<TUserKey,TCarKey> where TCarKey:struct
{
    private readonly ICarRepository<TCarKey> _carStatusRepository;
    private readonly ICarFactory _carFactory;

    public CarService(ICarRepository<TCarKey> carStatusRepository, ICarFactory carFactory)
    {
        _carStatusRepository = carStatusRepository;
        _carFactory = carFactory;
    }

    public async Task<ICarStatus> GetStatusAsync(TUserKey userId, TCarKey carKey, CancellationToken token)
    {
        var carTask = _carStatusRepository.GetAsync(carKey, token);
        var car = await carTask;
        var carStatus = _carFactory.CreateCarStatus(car);
        return carStatus;
    }
}