using Domain.Entities;

namespace WebApi.Contracts.Dtos;

public class TelegramContactDto:ITelegramContact
{
    public string Name { get; set; }
}