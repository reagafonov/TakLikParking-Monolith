using Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class UserDataConfiguration:IEntityTypeConfiguration<UserDataEntity>
{
    public void Configure(EntityTypeBuilder<UserDataEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Cars).WithMany(x => x.RegistrationData);
    }
}