namespace Infrastructure.EntityFramework.Models;

public class UserDataEntity
{
    public Guid Id { get; set; }
    
    public virtual ICollection<CarEntity> Cars { get; set; }
    
    public string Email { get; set; }
    
    public string Phone { get; set; }
    
    public string Telegram { get; set; }
    
    public string TelegramName { get; set; }
}