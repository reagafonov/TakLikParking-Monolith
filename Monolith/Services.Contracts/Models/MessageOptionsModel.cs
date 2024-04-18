using Domain.Entities;
using Domain.Entities.New;

namespace WebApi.Contracts.Dtos;

public class MessageOptionsModel:IMessageOptions
{
    public NotifyOptions NotifyOptions { get; set; }
}