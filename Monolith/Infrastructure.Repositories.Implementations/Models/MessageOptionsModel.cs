using Domain.Entities;

namespace Repositories.Implementations.New.Models;

public class MessageOptionsModel:IMessageOptions
{
    public NotifyOptions NotifyOptions { get; set; }
}