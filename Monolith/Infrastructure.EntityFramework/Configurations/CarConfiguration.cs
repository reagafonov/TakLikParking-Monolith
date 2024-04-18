using Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class CarConfiguration:IEntityTypeConfiguration<CarEntity>
{
    public void Configure(EntityTypeBuilder<CarEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.RegistrationData)
            .WithMany(x => x.Cars);
        builder.HasMany(x => x.MessageOptions).WithOne(x => x.CarEntity);
    }
}