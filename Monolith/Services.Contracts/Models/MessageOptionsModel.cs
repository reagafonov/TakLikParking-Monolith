using Domain.Entities;

namespace Services.Contracts.Models;

public class MessageOptionsModel:IMessageOptions
{
    public NotifyOptions NotifyOptions { get; set; }
}