namespace Domain.Entities;

public interface ITelegramContact:IContact
{
    string Name { get; set; }
}