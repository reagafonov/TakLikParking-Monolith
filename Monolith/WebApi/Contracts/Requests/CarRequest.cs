using Domain.Entities;

namespace WebApi.Contracts.Requests;

public class CarRequest
{
    public CarNumberRequest Number { get; set; }
    public Dictionary<MessageType, MessageOptionsRequest> MessageOptions { get; set; }
}