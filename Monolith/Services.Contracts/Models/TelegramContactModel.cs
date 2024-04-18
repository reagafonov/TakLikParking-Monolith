using Domain.Entities.New;

namespace WebApi.Contracts.Dtos;

public class TelegramContactModel:ITelegramContact
{
    public string Name { get; set; }
}