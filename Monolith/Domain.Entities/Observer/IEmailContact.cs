namespace Domain.Entities;

public interface IEmailContact:IContact
{
    string Email { get; set; }
}