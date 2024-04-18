using Domain.Entities;
using Domain.Entities.New;

namespace WebApi.Contracts.Dtos;

public class MessageOptionsDto:IMessageOptions
{
    public NotifyOptions NotifyOptions { get; set; }
}