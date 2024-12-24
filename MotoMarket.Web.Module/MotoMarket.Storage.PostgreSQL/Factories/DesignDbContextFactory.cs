using MotoMarket.Storage.PostgreSQL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MotoMarket.Storage.PostgreSQL.Factories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MainDBContext>
    {
        public MainDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MainDBContext>();

            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=moto_market_db;User ID=developer_user;Password=developer_user;CommandTimeout=20;Timeout=40",
                    builder => { builder.MigrationsAssembly("MotoMarket.Storage.PostgreSQL"); });

            return new MainDBContext(optionsBuilder.Options);
        }
    }
}
