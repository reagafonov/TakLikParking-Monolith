namespace Domain.Entities;

public class Parking<TKey> : IEntity<TKey> where TKey:struct
{
    public TKey Id { get; set; }

    // public string Address { get; set; }
    // public virtual ICollection<Role> Roles { get; set; }
    // public virtual ICollection<ParkingPlace> ParkingPlaces { get; set; }  
}