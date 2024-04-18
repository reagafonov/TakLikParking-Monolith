using Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.New;

public class DatabaseContext:DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }

    public DbSet<UserDataEntity> UserDatas { get; set; }
    public DbSet<CarEntity> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}