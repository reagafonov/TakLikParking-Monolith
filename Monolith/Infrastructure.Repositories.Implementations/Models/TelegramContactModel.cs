using Domain.Entities;

namespace Repositories.Implementations.New.Models;

public class TelegramContactModel:ITelegramContact
{
    public string Name { get; set; }
    public string ChatID { get; set; }
}