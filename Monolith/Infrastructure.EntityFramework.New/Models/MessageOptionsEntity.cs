using Domain.Entities;
using Infrastructure.EntityFramework.Models;

namespace Infrastructure.EntityFramework.New.Models;

public class MessageOptionsEntity
{
    public Guid Id { get; set; }
    
    public virtual CarEntity CarEntity { get; set; }
    
    public MessageType MessageType { get; set; }
    
    public NotifyOptions NotifyOptions { get; set; }
}