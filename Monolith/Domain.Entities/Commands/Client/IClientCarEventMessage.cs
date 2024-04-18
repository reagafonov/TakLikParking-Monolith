namespace Domain.Entities.Commands;

public interface IClientCarEventMessage
{
    string Number { get; set; }
    DateTime Date { get; set; }
    string Address { get; set; }
    string Text { get; set; }
    byte[] Image { get; set; }
}