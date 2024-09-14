using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Tresorix.Data;

namespace Data.Migrations;

public class TresorixContextFactory : IDesignTimeDbContextFactory<TresorixContext>
{
    public TresorixContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();

        var connectionString = args.Any() ? args[0] : configuration.GetConnectionString("DefaultConnection");
        var optionsBuilder = new DbContextOptionsBuilder<TresorixContext>();
        optionsBuilder.UseSqlServer(
            connectionString,
            b =>
            {
                b.MigrationsAssembly(GetType().Assembly.GetName().Name);
                b.CommandTimeout(600);
            });

        var dbContext = new TresorixContext(optionsBuilder.Options);

        return dbContext;
    }
}