
namespace Services.Contracts.Models;

public class ClientMessageModel
{
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public string Address { get; set; }
    public string Text { get; set; }
    public byte[] Image { get; set; }
}