using Domain.Entities;

namespace WebApi.Contracts.Requests;

public class MessageOptionsRequest:IMessageOptions
{
    public NotifyOptions NotifyOptions { get; set; }
}