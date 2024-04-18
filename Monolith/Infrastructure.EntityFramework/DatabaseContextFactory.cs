using Infrastructure.EntityFramework.New;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.EntityFramework;

public class DatabaseContextFactory:IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        var configuration = builder.Build();
        var connectionString = configuration["ConnectionString"];
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new Exception("Connection string is null.");
        var contextBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        contextBuilder.UseNpgsql(connectionString, opt => opt.MigrationsAssembly(GetType().Assembly.GetName().Name));
        return new DatabaseContext(contextBuilder.Options);
    }
}