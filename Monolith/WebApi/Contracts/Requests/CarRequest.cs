using Domain.Entities;
using Domain.Entities.New;

namespace WebApi.Contracts.Dtos;

public class CarRequest
{
    public CarNumberRequest Number { get; set; }
    public Dictionary<MessageType, MessageOptionsRequest> MessageOptions { get; set; }
}