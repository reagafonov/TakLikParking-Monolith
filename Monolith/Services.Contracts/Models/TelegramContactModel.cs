using Domain.Entities;

namespace Services.Contracts.Models;

public class TelegramContactModel:ITelegramContact
{
    public string Name { get; set; }
}