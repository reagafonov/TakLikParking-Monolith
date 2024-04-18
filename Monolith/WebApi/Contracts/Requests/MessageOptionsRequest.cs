using Domain.Entities;
using Domain.Entities.New;

namespace WebApi.Contracts.Dtos;

public class MessageOptionsRequest:IMessageOptions
{
    public NotifyOptions NotifyOptions { get; set; }
}