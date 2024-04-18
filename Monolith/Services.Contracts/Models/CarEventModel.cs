using Domain.Entities;

namespace Services.Contracts.Models;

public class CarEventModel
{
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public string Address { get; set; }
    public string Text { get; set; }
    public byte[] Image { get; set; }
    public MessageType Type { get; set; }
}