using Domain.Entities;

namespace WebApi.Contracts.Dtos;

public class MessageOptionsDto:IMessageOptions
{
    public NotifyOptions NotifyOptions { get; set; }
}