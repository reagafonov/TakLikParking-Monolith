using Infrastructure.EntityFramework.New.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.New.Configurations;

public class MessageOptionsConfiguration:IEntityTypeConfiguration<MessageOptionsEntity>
{
    public void Configure(EntityTypeBuilder<MessageOptionsEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.CarEntity).WithMany(x => x.MessageOptions);
    }
}