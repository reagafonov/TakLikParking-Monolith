using Domain.Entities;
using Domain.Entities.New;

namespace Services.Abstractions;

/// <summary>
/// интерфейс пользователя
/// User interface class
/// </summary>
/// <typeparam name="TUserKey">
///     Тип ключа пользователя
///     Key type of user
/// </typeparam>
/// <typeparam name="TCarKey">
///     Тип ключа автомобиля
///     Key type of car
/// </typeparam>
public interface IUserService<TUserKey,TCarKey> where TUserKey:struct where TCarKey:struct
{
    /// <summary>
    /// Создает нового пользователя
    /// Creating new user
    /// </summary>
    /// <param name="userData">
    ///     Данные пользователя
    ///     User data
    /// </param>
    /// <param name="token">
    ///     Токен отмены
    ///     cancellation token
    /// </param>
    /// <returns></returns>
    Task CreateAsync(IUserData<TUserKey> userData, CancellationToken token);
    
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

    /// <summary>
    /// Применяет шаблон оповещений к выбранной машине
    /// Applies notification template to selected car of selected user
    /// </summary>
    /// <param name="userId">
    ///     идентификатор пользователя
    ///     user identifier
    /// </param>
    /// <param name="carKey">
    ///     идентификатор автомобиля
    ///     car identifier
    /// </param>
    /// <param name="type">
    ///     Набор событий
    ///     Event types set
    /// </param>
    /// <param name="options">
    ///     Набор вариантов оповещения
    ///     Notification types set
    /// </param>
    /// <param name="token"></param>
    /// <returns></returns>
    Task SetNotificationOptionsAsync(TUserKey userId, TCarKey carKey, MessageType type, NotifyOptions options,
        CancellationToken token);
}