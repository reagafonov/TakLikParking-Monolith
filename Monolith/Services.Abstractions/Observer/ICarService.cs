using Domain.Entities;

namespace Services.Abstractions.New;

public interface ICarService<TUserKey,TCarKey>
{
    /// <summary>
    /// Возвращает данные машины
    /// Returns current status of car
    /// </summary>
    /// <param name="userId">
    ///     идентификатор пользователя
    ///     user identifier
    /// </param>
    /// <param name="carKey">
    ///     идентификатор машины
    ///     car identifier
    /// </param>
    /// <param name="token">
    ///     Токен отмены
    ///     cancellation token
    /// </param>
    /// <returns>
    ///     Данные автомобиля
    ///     ICar status data
    /// </returns>
    Task<ICarStatus> GetStatusAsync(TUserKey userId, TCarKey carKey, CancellationToken token);
}